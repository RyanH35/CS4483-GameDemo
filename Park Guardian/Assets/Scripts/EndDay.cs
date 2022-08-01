using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndDay : MonoBehaviour
{

    public Text playerPrompt;
    private bool isIn;
    // Start is called before the first frame update
    void Start()
    {
        //disable UI prompt
        playerPrompt.transform.localScale = new Vector2(0,0);
        isIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isIn)
        {
            if(Input.GetKeyUp("e"))
            {
                SceneManager.LoadScene("EndOfDay");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        isIn = true;
        //show interact prompt
        playerPrompt.transform.localScale = new Vector2(1,1);
    }

    void OnCollisionExit2D(Collision2D col)
    {
        isIn = false;
        //remove interact prompt
        playerPrompt.transform.localScale = new Vector2(0,0);
    }
}
