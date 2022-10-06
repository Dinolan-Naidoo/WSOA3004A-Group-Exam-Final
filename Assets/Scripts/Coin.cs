using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Coin : MonoBehaviour
{

    //The following funtion checks whether the player has collided with a coin and destroys the coin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //coinImg.enabled = true;
            Destroy(gameObject);
        }
    }
    
}
