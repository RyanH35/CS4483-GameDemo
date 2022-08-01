using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Teaser : MonoBehaviour
{
    private float timer;
    public GameObject[] textArr;
    bool canProceed = false;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i < textArr.Length; i++)
        {
            textArr[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Load in each UI segment sequentially
        timer += Time.deltaTime;
        for(int i = 1; i < textArr.Length; i++)
        {
            if(timer > 2*i)
            {
                textArr[i].SetActive(true);
                if(i == textArr.Length-1)
                {
                    canProceed = true;
                }
            }
        }
        if(canProceed)
        {
            if(Input.GetKeyDown(KeyCode.Return) || Input.GetKey ("enter"))
            {
                SceneManager.LoadScene("Day3");
            }
        }
    }
}
