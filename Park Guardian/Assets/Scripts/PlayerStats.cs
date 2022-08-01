using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
   public static PlayerStats playerStats;

   // player ability scores
   private int strength;
   private int endurance;
   private int natIntelligence;
   private int charisma;
   private int medIntelligence;
   private int investigation;

   // player experience scores (used to track when associated ability score should be increased)
   public int strengthExp;
   public int enduranceExp;
   public int natIntelligenceExp;
   public int charismaExp;
   public int medIntelligenceExp;
   public int investigationExp;

   public int currentDayNumber;
   public int dailyTasksCompleted;
   public int dailyTaskCount;

   //private int maxScore = 10;

    // create singleton of player object
   void Awake()
   {
         if(playerStats != null)
         {
            GameObject.Destroy(playerStats.gameObject);
         }
         else
            playerStats = this;
        
         DontDestroyOnLoad(this);
   }

   //Getter methods
   public int getStrength(){return strength;}
   public int getEndurance(){return endurance;}
   public int getNatIntelligence(){return natIntelligence;}
   public int getMedIntelligence(){return medIntelligence;}
   public int getCharisma(){return charisma;}
   public int getInvestigation(){return investigation;}
   //Methods to change ability scores
   public void changeStrength(int x){strength += x;}
   public void changeEndurance(int x){endurance += x;}
   public void changeNatIntelligence(int x){natIntelligence += x;}
   public void changeMedIntelligence(int x){medIntelligence += x;}
   public void changeCharisma(int x){charisma += x;}
   public void changeInvestigation(int x){investigation += x;}
}
