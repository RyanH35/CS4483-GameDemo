using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject dialogBox;
    public float dialogTime = 3.5f;
    public float currentDialogTime = -1.0f;
    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(currentDialogTime >= 0)
        {
            currentDialogTime -= Time.deltaTime;
            if(currentDialogTime < 0)
            {
                dialogBox.SetActive(false);
            }
        }
        
    }
    public void talk()
    {
        currentDialogTime = dialogTime;
        dialogBox.SetActive(true);
    }
}
