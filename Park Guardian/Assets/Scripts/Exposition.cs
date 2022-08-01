using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exposition : MonoBehaviour
{
    private PlayerStats allPlayerStats;
    // Start is called before the first frame update
    void Start()
    {
        allPlayerStats = GameObject.Find("PlayerStatsManager").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKey ("enter"))
        {
            //wait for player input then load the next scene
            SceneManager.LoadScene("Day" + allPlayerStats.currentDayNumber.ToString());
        }        
    }
}
