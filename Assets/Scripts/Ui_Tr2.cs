using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ui_Tr2 : MonoBehaviour
{
    //Controls the second part of the tutorial

    public GameObject UI_Text1;

    private void Start()
    {
        UI_Text1.SetActive(false);
    }

    //Enables the UI
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            UI_Text1.SetActive(true);
        }
    }

    //Disables the UI
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            UI_Text1.SetActive(false);
        }

    }
}
