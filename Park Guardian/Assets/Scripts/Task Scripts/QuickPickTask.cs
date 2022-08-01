using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickPickTask : Task
{
    [SerializeField]
    private float reactTimeLimit = 1.0f;
    private float delayTimer = 2.0f;
    private float delayTimeLeft;
    private float reactTimeLeft;
    private List<string> buttonList = new List<string>()
    {
        "q",
        "r",
        "c"       
    };
    new void Start()
    {
        base.Start();
        IListExtensions.Shuffle(buttonList);
        delayTimeLeft = delayTimer;
        reactTimeLeft = reactTimeLimit;
    }
    // Update is called once per frame
    void Update()
    {
        if(isIn && canPerform)
        {
            delayTimeLeft -= Time.deltaTime;
            if(delayTimeLeft < 0)
            {
                if(reactTimeLeft > 0)
                {
                    playerPrompt.text = "Press " + buttonList[0].ToUpper();
                    if(Input.GetKeyUp(buttonList[0]))
                    {
                        awardXP();
                        removeTask();
                    }
                    reactTimeLeft -= Time.deltaTime;
                }    
                else{
                    playerPrompt.text = "Try Again";
                    IListExtensions.Shuffle(buttonList);
                    reactTimeLeft = reactTimeLimit;
                    delayTimeLeft = delayTimer;
                }
            }
        }    
    }
    public override void OnCollisionEnter2D(Collision2D col)
    {
        isIn = true;
        //display interact prompt, differs depending on if level requirement is met
        if(canPerform == true)
        {
            playerPrompt.text = "React Quickly...";
            playerPrompt.transform.localScale = new Vector2(1,1);
        }
        else
        {
            insufficientLevelText();
        }
    }
    new void OnCollisionExit2D(Collision2D col)
    {
        base.OnCollisionExit2D(col);
        IListExtensions.Shuffle(buttonList);
        delayTimeLeft = delayTimer;
        reactTimeLeft = reactTimeLimit;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        isIn = true;
        if(canPerform == true)
        {
            playerPrompt.text = "React Quickly...";
            playerPrompt.transform.localScale = new Vector2(1,1);
        }
        else
        {
            insufficientLevelText();
        }
    } 
    void OnTriggerExit2D(Collider2D col)
    {
        isIn = false;
        //remove interact prompt
        playerPrompt.transform.localScale = new Vector2(0,0);
        IListExtensions.Shuffle(buttonList);
        delayTimeLeft = delayTimer;
        reactTimeLeft = reactTimeLimit;
    }
}
