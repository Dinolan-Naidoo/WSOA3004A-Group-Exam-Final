using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal1 : MonoBehaviour
{
    private Scene scene;
    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.gameObject.tag == "Player")
        {
            if (scene.name == "Level1")
            {
                SceneManager.LoadScene("L1Interval");
            }

            if (scene.name == "Level2")
            {
                SceneManager.LoadScene("L2Interval");
            }


        }
    }
}
