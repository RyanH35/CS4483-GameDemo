using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Character Creation");
    }
    public void loadGame()
    {

    }
    public void exitGame()
    {
        Application.Quit();
    }
}
