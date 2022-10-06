using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class scene_manager : MonoBehaviour
{
    //The following script handles the button control between scenes
 public void PlayL1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void PlayL2()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void loadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
