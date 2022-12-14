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

    public void Level1_Death_1()
    {
        SceneManager.LoadScene("Level1Retry");
    }

    public void Level1_Death_2()
    {
        SceneManager.LoadScene("Level1_1Retry");
    }
    public void PlayL2()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void PlayLevel2_2()
    {
        SceneManager.LoadScene("Level2_2");
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene("Level3");
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

    public void IntroScene()
    {
        SceneManager.LoadScene("IntroScene");
    }


}
