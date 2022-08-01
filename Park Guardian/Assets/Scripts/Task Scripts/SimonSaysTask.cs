using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IListExtensions
{
    public static void Shuffle<T>(this IList<T> ts) {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i) {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}

public class SimonSaysTask : Task
{
    private float delayTimer = 2.0f;
    private float timeLeft;
    //keep track of how many successful buttons the player has pressed
    private int progress = 0;

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
        timeLeft = delayTimer;
        progress = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(isIn && canPerform)
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0)
            {
                playerPrompt.text = "Press " + buttonList[progress].ToUpper();
                if(Input.GetKeyUp(buttonList[progress]))
                {
                    progress++;
                }
                if(progress == 3)
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
            playerPrompt.text = "Get Ready...";
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
        timeLeft = delayTimer;
        progress = 0;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        isIn = true;
        //display interact prompt, differs depending on if level requirement is met
        if(canPerform == true)
        {
            playerPrompt.text = "Get Ready...";
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
        timeLeft = delayTimer;
        progress = 0;
    }

}
