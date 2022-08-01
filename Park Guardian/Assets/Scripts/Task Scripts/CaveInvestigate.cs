using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveInvestigate : Task
{
    // Update is called once per frame
    void Update()
    {
        if(isIn)
        {
            if(Input.GetKeyUp("e"))
            {
                SceneManager.LoadScene("Teaser");
            }
        }
        
    }
    public override void OnCollisionEnter2D(Collision2D col)
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        isIn = true;
        playerPrompt.text = "Press E to enter the cave...";
        playerPrompt.transform.localScale = new Vector2(1,1);
    }
    void OnTriggerExit2D(Collider2D col)
    {
        isIn = false;
        //remove interact prompt
        playerPrompt.transform.localScale = new Vector2(0,0);
    }
}
