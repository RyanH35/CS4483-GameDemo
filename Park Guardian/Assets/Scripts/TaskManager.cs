using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct similarTask
{
    public Task[] taskList;
}

public class TaskManager : MonoBehaviour
{
    public Canvas taskCanvas;
    public Text todoText;

    private PlayerStats allPlayerStats;

    public similarTask[] taskType;
    //list will keep track of total task to complete of each type
    // for example, taskTotals[0] = 3 if there are tasks in taskTypes[0]
    private List<int> taskTotals = new List<int>();
    //list will keep track of number of completed tasks of each type
    private List<int> taskCompletions = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        allPlayerStats = GameObject.Find("PlayerStatsManager").GetComponent<PlayerStats>();
        initializeText();
        allPlayerStats.dailyTaskCount = 0;
        allPlayerStats.dailyTasksCompleted = 0;
        for(int i = 0; i < taskTotals.Count; i++)
        {
            allPlayerStats.dailyTaskCount += taskTotals[i];
        }
    }

    void initializeText()
    {
        //for each type of task
        for(int i = 0; i < taskType.Length; i++)
        {
            // print task name and number of associated tasks
            if(taskType[i].taskList.Length > 0)
            {
                //add task name to UI text
                todoText.text = todoText.text + taskType[i].taskList[0].taskName;
            }
            //add the number of tasks to taskTotals
            taskTotals.Add(taskType[i].taskList.Length);
            taskCompletions.Add(0);
            //add number of tasks to UI text
            todoText.text = todoText.text + " 0/" + taskTotals[i] + "\n";
        }
    }
    public void updateText(GameObject updatedTask)
    {
        todoText.text = "";
        //for each type of task
        for(int i = 0; i < taskType.Length; i++)
        {
            //add task name to UI text
            todoText.text = todoText.text + taskType[i].taskList[0].taskName;
            //for each task of a certain type
            for(int j = 0; j < taskType[i].taskList.Length; j++)
            {
                //check if not null to avoid errors
                if(taskType[i].taskList[j] != null)
                {
                    //This task has been completed
                    if(updatedTask.gameObject == taskType[i].taskList[j].gameObject)
                    {
                        taskCompletions[i]++;
                        allPlayerStats.dailyTasksCompleted++;
                    }
                }
                
            }
            //add number of tasks to UI text
            todoText.text = todoText.text + " " + taskCompletions[i] + "/" + taskTotals[i] + "\n";
        }
    }
}
