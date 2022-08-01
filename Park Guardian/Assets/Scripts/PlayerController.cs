using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float defaultMoveSpeed = 5.0f;
    public float sprintMoveSpeed = 6.5f;
    private float moveSpeed;
    public float maxSprint = 1.5f;
    private float sprintTimer;
    private bool isSprinting = false;
    private int enduranceScore;

    Animator animator;
    string lastDirection;
    Vector2 lookDirection = new Vector2(1,0);

    Rigidbody2D playerRigidbody;
    float horizontal;
    float vertical;

    //pause variables
    private bool gamePaused = false;
    public GameObject pauseMenu;

    //timer variables
    public Text timer;
    private int minutes;
    private int seconds;
    [SerializeField]
    private float timeLeft;

    private bool showToDo = true;
    public GameObject todoList;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveSpeed = defaultMoveSpeed;
        pauseMenu.SetActive(false);
        enduranceScore = GameObject.Find("PlayerStatsManager").GetComponent<PlayerStats>().getEndurance();
        isSprinting = false;
        maxSprint += (float)(enduranceScore*0.5);
        sprintTimer = maxSprint;
        //5 minute timer by default
        timeLeft = 300;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //handle movement speed (check if sprinting)
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
        }
        if(isSprinting && sprintTimer > 0)
        {
            StaminaBar.barInstance.SetValue(sprintTimer / maxSprint);
            moveSpeed = sprintMoveSpeed;
            sprintTimer -= Time.deltaTime;
        }
        else
        {
            isSprinting = false;
            moveSpeed = defaultMoveSpeed;
            if(sprintTimer < maxSprint)
            {
                sprintTimer += Time.deltaTime;
                StaminaBar.barInstance.SetValue(sprintTimer / maxSprint);
            }
            else{
                sprintTimer = maxSprint;
            }
            
        }
        //animation handeling 
        if(horizontal > 0)
        {
            animator.SetBool("movingRight", true);
            lastDirection = "right";
            animator.SetBool("movingLeft", false);
            lookDirection.x = 1;
        }
        else if(horizontal < 0)
        {
            animator.SetBool("movingRight", false);
            lastDirection = "left";
            animator.SetBool("movingLeft", true);
            lookDirection.x = -1;
        }
        else if(vertical != 0)
        {
            switch(lastDirection)
            {
                case "left":
                    animator.SetBool("movingLeft", true);
                    animator.SetBool("movingRight", false);
                    break;
                case "right":
                    animator.SetBool("movingRight", true);
                    animator.SetBool("movingLeft", false);
                    break;
                default:
                    break;
            }
        }
        else
        {
            animator.SetBool("movingRight", false);
            animator.SetBool("movingLeft", false);
        }
        
        //check if talking to someone
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D hit = Physics2D.Raycast(playerRigidbody.position + Vector2.up * 0.5f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            Debug.DrawRay(playerRigidbody.position + Vector2.up * 0.5f, lookDirection, Color.yellow, 10.0f);
            if (hit.collider != null)
            {
                NPC character = hit.collider.GetComponent<NPC>();
                if (character != null)
                {
                    character.talk();
                }
            }
        }

        //pause
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gamePaused)
            {
                UnPause();
            }
            else
            {
                Pause();
            }
            
        }
        //timer handling
        timeLeft -= Time.deltaTime;
        minutes = Mathf.FloorToInt(timeLeft / 60);  
        seconds = Mathf.FloorToInt(timeLeft % 60);
        timer.text = string.Format("Time Remaining: {0:00}:{1:00}", minutes, seconds);
        if(timeLeft < 0)
        {
            SceneManager.LoadScene("EndOfDay");
        }
        //Show/Hide tasks
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(showToDo)
            {
                showToDo = false;
                todoList.SetActive(false);
            }
            else
            {
                showToDo = true;
                todoList.SetActive(true);
            }
        }
    }
    void FixedUpdate()
    {
        Vector2 position = playerRigidbody.position;
        Vector2 movementVector  = new Vector2(horizontal * Time.deltaTime, vertical * Time.deltaTime);
        movementVector = movementVector * moveSpeed;
        //stops diagonal movement from being faster
        movementVector = Vector2.ClampMagnitude(movementVector, moveSpeed*Time.deltaTime);
        position += movementVector;
        playerRigidbody.MovePosition(position);
    }

    //pause menu methods
    void Pause()
    {
        Time.timeScale = 0f;
        gamePaused = true;
        pauseMenu.SetActive(true);
    }
    public void UnPause()
    {
        Time.timeScale = 1f;
        gamePaused = false;
        pauseMenu.SetActive(false);
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void mainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}
