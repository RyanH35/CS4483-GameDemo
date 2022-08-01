using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldTask : Task
{
    private float heldTime;
    public float timeToHold = 5.0f;

    //private bool canPerform = false;
    // Update is called once per frame
    void Update()
    {
        if(isIn && canPerform)
        {
            //prompt user to perform task
            
            //check if user has held key down for sufficient time
            if(Input.GetKey(KeyCode.Space))
            {
                heldTime += Time.deltaTime;
                //check if task complete
                if(heldTime > timeToHold)
                {
                    awardXP();
                    removeTask();
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
            playerPrompt.text = "Hold 'Spacebar'";
            playerPrompt.transform.localScale = new Vector2(1,1);
        }
        else
        {
            insufficientLevelText();
        }
    }

}
