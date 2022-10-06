using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ui_Tr3 : MonoBehaviour
{
    //Controls the third part of the tutorial
    public GameObject UI_Text1;
    public GameObject enemy;

    private void Start()
    {
        UI_Text1.SetActive(false);
        enemy.SetActive(false);
    }

    //Enables the UI
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            UI_Text1.SetActive(true);
            enemy.SetActive(true);
        }
    }

    //Disables the UI
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            UI_Text1.SetActive(false);
            enemy.SetActive(false);
        }

    }
}
