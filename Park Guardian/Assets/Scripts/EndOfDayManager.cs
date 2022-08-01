using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndOfDayManager : MonoBehaviour
{
    private PlayerStats allPlayerStats;
    private float timer;

    private int prevStatScore;

    public Text newStrengthScore;
    public Text prevStrengthScore;
    public Text newEnduranceScore;
    public Text prevEnduranceScore;
    public Text newMedIntScore;
    public Text prevMedIntScore;
    public Text newNatIntScore;
    public Text prevNatIntScore;
    public Text newCharismaScore;
    public Text prevCharismaScore;
    public Text newInvestigationScore;
    public Text prevInvestigationScore;

    public Text tasksAssigned;
    public Text tasksCompleted;
    public Text completionRate;
    public Text noteText;

    public GameObject playerStatSummary;
    public GameObject playerTaskSummary;
    public GameObject continueButton;


    // Start is called before the first frame update
    void Start()
    {
        allPlayerStats = GameObject.Find("PlayerStatsManager").GetComponent<PlayerStats>();

        //strength
        prevStatScore = allPlayerStats.getStrength();
        //check if player has enough xp to level up in a skill
        while(allPlayerStats.strengthExp >= (100 + ( 10*allPlayerStats.getStrength() ) ) )
        {
            //adjust xp
            allPlayerStats.strengthExp -= (100 + ( 10*allPlayerStats.getStrength() ) );
            //grant a level
            allPlayerStats.changeStrength(1);
        }
        //update UI to show player stats
        prevStrengthScore.text = prevStatScore.ToString();
        newStrengthScore.text = allPlayerStats.getStrength().ToString();
        //change new stat text to green if there is a change in the score
        if (prevStatScore != allPlayerStats.getStrength())
        {
            newStrengthScore.color = Color.green;
        }

        //endurance
        prevStatScore = allPlayerStats.getEndurance();
        while(allPlayerStats.enduranceExp >= (100 + ( 10*allPlayerStats.getEndurance() ) ) )
        {
            allPlayerStats.enduranceExp -= (100 + ( 10*allPlayerStats.getEndurance() ) );
            allPlayerStats.changeEndurance(1);
        }
        prevEnduranceScore.text = prevStatScore.ToString();
        newEnduranceScore.text = allPlayerStats.getEndurance().ToString();
        if (prevStatScore != allPlayerStats.getEndurance())
        {
            newEnduranceScore.color = Color.green;
        }

        //natural intelligence
        prevStatScore = allPlayerStats.getNatIntelligence();
        while(allPlayerStats.natIntelligenceExp >= (100 + ( 10*allPlayerStats.getNatIntelligence() ) ) )
        {
            allPlayerStats.natIntelligenceExp -= (100 + ( 10*allPlayerStats.getNatIntelligence() ) );
            allPlayerStats.changeNatIntelligence(1);
        }
        prevNatIntScore.text = prevStatScore.ToString();
        newNatIntScore.text = allPlayerStats.getNatIntelligence().ToString();
        if (prevStatScore != allPlayerStats.getNatIntelligence())
        {
            newNatIntScore.color = Color.green;
        }

        //medical intelligence
        prevStatScore = allPlayerStats.getMedIntelligence();
        while(allPlayerStats.medIntelligenceExp >= (100 + ( 10*allPlayerStats.getMedIntelligence() ) ) )
        {
            allPlayerStats.medIntelligenceExp -= (100 + ( 10*allPlayerStats.getMedIntelligence() ) );
            allPlayerStats.changeMedIntelligence(1);
        }
        prevMedIntScore.text = prevStatScore.ToString();
        newMedIntScore.text = allPlayerStats.getMedIntelligence().ToString();
        if (prevStatScore != allPlayerStats.getMedIntelligence())
        {
            newMedIntScore.color = Color.green;
        }

        //charisma
        prevStatScore = allPlayerStats.getCharisma();
        while(allPlayerStats.charismaExp >= (100 + ( 10*allPlayerStats.getCharisma() ) ) )
        {
            allPlayerStats.charismaExp -= (100 + ( 10*allPlayerStats.getCharisma() ) );
            allPlayerStats.changeCharisma(1);
        }
        prevCharismaScore.text = prevStatScore.ToString();
        newCharismaScore.text = allPlayerStats.getCharisma().ToString();
        if (prevStatScore != allPlayerStats.getCharisma())
        {
            newCharismaScore.color = Color.green;
        }

        //investigation
        prevStatScore = allPlayerStats.getInvestigation();
        while(allPlayerStats.investigationExp >= (100 + ( 10*allPlayerStats.getInvestigation() ) ) )
        {
            allPlayerStats.investigationExp -= (100 + ( 10*allPlayerStats.getInvestigation() ) );
            allPlayerStats.changeInvestigation(1);
        }
        prevInvestigationScore.text = prevStatScore.ToString();
        newInvestigationScore.text = allPlayerStats.getInvestigation().ToString();
        if (prevStatScore != allPlayerStats.getInvestigation())
        {
            newInvestigationScore.color = Color.green;
        }

        tasksAssigned.text = "Tasks Assigned: " + allPlayerStats.dailyTaskCount.ToString();
        tasksCompleted.text = "Tasks Completed: " + allPlayerStats.dailyTasksCompleted.ToString();
        float completionRateFloat = ((float)allPlayerStats.dailyTasksCompleted / (float)allPlayerStats.dailyTaskCount) * 100;
        completionRate.text = "Completion Rate: " + completionRateFloat.ToString("F2") + "%";
        //choose message to print depending on how the percentage of required tasks the user completed
        if(completionRateFloat == 100)
        {
            noteText.text = "Fantastic Work!\nYou are making Pandora Park proud!";
        }
        else if(completionRateFloat >= 50)
        {
            noteText.text = "Good Job.\nYou are on your way to becoming a great park ranger.";
        }
        else
        {
            noteText.text = "Disappointing.\nManagement expects better from you.";
        }
        playerStatSummary.SetActive(false);
        playerTaskSummary.SetActive(false);
        continueButton.SetActive(false);
        allPlayerStats.currentDayNumber++;
    }

    // Update is called once per frame
    void Update()
    {
        //Load in each UI segment sequentially
        timer += Time.deltaTime;
        if(timer > 2)
        {
            playerStatSummary.SetActive(true);
        }
        if(timer > 4)
        {
            playerTaskSummary.SetActive(true);
        }
        if(timer > 6)
        {
            continueButton.SetActive(true);
        }
    }

    //used by a button to allow the player to advance the scene
    public void Continue()
    {
        //Load new scene using allPlayerStats.currentDayNumber;
        SceneManager.LoadScene("Day" + allPlayerStats.currentDayNumber.ToString());
    }
}
