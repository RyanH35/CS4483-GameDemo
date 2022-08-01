using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidTask : Task
{
    private int count = 0;
    [SerializeField]
    private int maxCount = 10;
    // Update is called once per frame
    void Update()
    {
        if(isIn && canPerform)
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                count += 1;
            }
        }
        else
        {
            count = 0;
        }
        if(count >= maxCount)
        {
            awardXP();
            removeTask();
        }
        
    }
    public override void OnCollisionEnter2D(Collision2D col)
    {
        isIn = true;
        //display interact prompt, differs depending on if level requirement is met
        if(canPerform == true)
        {
            playerPrompt.text = "Rapidly Press 'Spacebar'";
            playerPrompt.transform.localScale = new Vector2(1,1);
        }
        else
        {
            insufficientLevelText();
        }
    }
}
