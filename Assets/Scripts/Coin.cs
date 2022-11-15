using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Coin : MonoBehaviour
{
    public ParticleSystem collectedOrb;

    public Transform orb;

    //The following funtion checks whether the player has collided with a coin and destroys the coin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(collectedOrb, orb.transform.position, orb.transform.rotation);
            //coinImg.enabled = true;
            Destroy(gameObject);
        }
    }
    
}
