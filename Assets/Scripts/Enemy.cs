using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform FirePoint;      //Spawn point for bullets
    private float TimedShots;        //Timing between shots
    public float startShooting;      //Starting time for shooting
    Object bulletRef;                //Reference to the bullet prefab


    private void Start()
    {
        //Makes sure that Timed shots ans start shooting are equal to each other at the start of the game
        TimedShots = startShooting;

        //References the bullet prefab in the resources folder
        bulletRef = Resources.Load("Bullet");
    }


    void Update()
    {

        if (TimedShots <= 0)
        {
            //Shoots a bullet once the timer has reached 0
            shoot();

            //Makes sure that timed shots is equal to start shooting at this instant
            TimedShots = startShooting;
        }
        else
        {
            //Operates as a decrement timer
            TimedShots -= Time.deltaTime;
        }

    }

    //Instantiates bullets at specific FirePoint 
    void shoot()
    {
        Instantiate(bulletRef, FirePoint.position, FirePoint.rotation);
    }
}
