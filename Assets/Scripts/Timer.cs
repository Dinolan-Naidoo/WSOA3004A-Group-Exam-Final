using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    //Variables for timer
    float currentTime = 0f;
    float startingTime = 15f;
    public Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {
        //Decrements time. Once time is over the game ends
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");
        if(currentTime <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

    }
}
