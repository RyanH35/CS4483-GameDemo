using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviour
{
    public PlayerStats playerStats;

    public Text abilityPoints;
    public Text strengthScore;
    public Text enduranceScore;
    public Text charismaScore;
    public Text investigationScore;
    public Text natIntelligenceScore;
    public Text medIntelligenceScore;

    public int pointsAvailable = 5;

    // Update is called once per frame
    void Update()
    {
        abilityPoints.text = pointsAvailable.ToString();
        strengthScore.text = playerStats.getStrength().ToString();
        enduranceScore.text = playerStats.getEndurance().ToString();
        charismaScore.text = playerStats.getCharisma().ToString();
        investigationScore.text = playerStats.getInvestigation().ToString();
        natIntelligenceScore.text = playerStats.getNatIntelligence().ToString();
        medIntelligenceScore.text = playerStats.getMedIntelligence().ToString();

    }

    public void confirmStats()
    {
        playerStats.currentDayNumber = 1;
        SceneManager.LoadScene("Introduction");
    }

    public void changeStrength(int x)
    {
        //adding points to strength
        if(x > 0)
        {
            if(pointsAvailable > 0)
            {
                playerStats.changeStrength(x);
                pointsAvailable--;
            }
        }
        //removing points from strength
        else
        {
            if(playerStats.getStrength() + x >= 0)
            {
                playerStats.changeStrength(x);
                pointsAvailable++;
            }
        }
    }
    public void changeEndurance(int x)
    {
        if(x > 0)
        {
            if(pointsAvailable > 0)
            {
                playerStats.changeEndurance(x);
                pointsAvailable--;
            }
        }
        else
        {
            if(playerStats.getEndurance() + x >= 0)
            {
                playerStats.changeEndurance(x);
                pointsAvailable++;
            }
        }
    }
    public void changeNatIntelligence(int x)
    {
        if(x > 0)
        {
            if(pointsAvailable > 0)
            {
                playerStats.changeNatIntelligence(x);
                pointsAvailable--;
            }
        }
        else
        {
            if(playerStats.getNatIntelligence() + x >= 0)
            {
                playerStats.changeNatIntelligence(x);
                pointsAvailable++;
            }
        }
    }
    public void changeMedIntelligence(int x)
    {
        if(x > 0)
        {
            if(pointsAvailable > 0)
            {
                playerStats.changeMedIntelligence(x);
                pointsAvailable--;
            }
        }
        else
        {
            if(playerStats.getMedIntelligence() + x >= 0)
            {
                playerStats.changeMedIntelligence(x);
                pointsAvailable++;
            }
        }
    }
    public void changeCharisma(int x)
    {
        if(x > 0)
        {
            if(pointsAvailable > 0)
            {
                playerStats.changeCharisma(x);
                pointsAvailable--;
            }
        }
        else
        {
            if(playerStats.getCharisma() + x >= 0)
            {
                playerStats.changeCharisma(x);
                pointsAvailable++;
            }
        }
    }
    public void changeInvestigation(int x)
    {
        if(x > 0)
        {
            if(pointsAvailable > 0)
            {
                playerStats.changeInvestigation(x);
                pointsAvailable--;
            }
        }
        else
        {
            if(playerStats.getInvestigation() + x >= 0)
            {
                playerStats.changeInvestigation(x);
                pointsAvailable++;
            }
        }
    }
}
