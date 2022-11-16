using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitWall : MonoBehaviour
{
    public Transform Player;
    public bool WallTrigger = false;
    public GameObject hitEffect;
    public float livetime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(hitEffect, livetime);
    }

    // Update is called once per frame
    void Update()
    {
        if (WallTrigger == true)
        {
            Debug.Log("Wall Hit");
            Instantiate(hitEffect, Player.position, Player.rotation);
            WallTrigger = false;
        }


    }

    public void OnCollisionEnter2D(Collision2D collision2D)
    {
        //WATER
        if (collision2D.gameObject.tag == "Wall")
        {
            WallTrigger = true;
        }
    }

    }
