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

    public GameObject portal;

    void Start()
    {
        currentTime = startingTime;
        portal.gameObject.SetActive(false);
    }
    void Update()
    {
        //Decrements time. Once time is over the game ends
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");
        if(currentTime <= 0)
        {
            portal.gameObject.SetActive(true);
            countdownText.text = "ACTIVE";

        }

    }
}
