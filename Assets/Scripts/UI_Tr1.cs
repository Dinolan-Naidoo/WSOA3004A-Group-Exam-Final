using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Tr1 : MonoBehaviour
{
    //Controls the first part of the tutorial
    public GameObject UI_Text1;
    public GameObject blockImage;

   //Disables the UI
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            UI_Text1.SetActive(false);
            blockImage.SetActive(false);
        }
    }

   
}
