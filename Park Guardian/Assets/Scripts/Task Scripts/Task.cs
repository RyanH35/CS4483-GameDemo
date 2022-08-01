using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class Task : MonoBehaviour
{
    public TaskData taskData;
    public string taskName = "task";

    protected bool isIn = false;
    protected bool canPerform = false;

    protected PlayerStats allPlayerStats;
    protected int playerStatLevel;

    public Text playerPrompt;

    private TaskManager taskManager;
    
    // Start is called before the first frame update
    protected void Start()
    {
        //disable UI prompt
        playerPrompt.transform.localScale = new Vector2(0,0);
        //get player stats
        allPlayerStats = GameObject.Find("PlayerStatsManager").GetComponent<PlayerStats>();
        switch(taskData.abilityReq.ToString())
        {
            case "Strength":
                playerStatLevel = allPlayerStats.getStrength();
                break;
            case "Endurance":
                playerStatLevel = allPlayerStats.getEndurance();
                break;
            case "NaturalIntelligence":
                playerStatLevel = allPlayerStats.getNatIntelligence();
                break;
            case "MedicalIntelligence":
                playerStatLevel = allPlayerStats.getMedIntelligence();
                break;
            case "Charisma":
                playerStatLevel = allPlayerStats.getCharisma();
                break;
            case "Investigation":
                playerStatLevel = allPlayerStats.getInvestigation();
                break;
        }
        //check level requirement
        if(playerStatLevel >= taskData.levelReq)
        {
            canPerform = true;
        }
    }
    abstract public void OnCollisionEnter2D(Collision2D col);

    protected void OnCollisionExit2D(Collision2D col)
    {
        isIn = false;
        //remove interact prompt
        playerPrompt.transform.localScale = new Vector2(0,0);
    }
    protected void insufficientLevelText()
    {
        playerPrompt.text = "Requires level " + taskData.levelReq.ToString() + " " + taskData.abilityReq.ToString()
        + ".\n Current: " + playerStatLevel.ToString();
        playerPrompt.transform.localScale = new Vector2(1,1);
    }
    protected void awardXP()
    {
        switch(taskData.abilityReq.ToString())
        {
            case "Strength":
                allPlayerStats.strengthExp += taskData.xpReward;
                break;
            case "Endurance":
                allPlayerStats.enduranceExp += taskData.xpReward;
                break;
            case "NaturalIntelligence":
                allPlayerStats.natIntelligenceExp += taskData.xpReward;
                break;
            case "MedicalIntelligence":
                allPlayerStats.medIntelligenceExp += taskData.xpReward;
                break;
            case "Charisma":
                allPlayerStats.charismaExp += taskData.xpReward;
                break;
            case "Investigation":
                allPlayerStats.investigationExp += taskData.xpReward;
                break;
        }
    }
    protected void removeTask()
    {
        //update task manager
        try
        {
            taskManager = GameObject.Find("TaskManager").GetComponent(typeof(TaskManager)) as TaskManager;
            taskManager.updateText(gameObject);
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
        //delete from scene
        Destroy(gameObject);
    }
}
