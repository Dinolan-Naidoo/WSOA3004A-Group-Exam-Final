using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    //Variables for projectile control
    public float speed;
    private Transform player;
    public Vector2 target;
    public GameObject impactEffect;

    private Scene scene;

    private void Start()
    {
        //Checks for the "Player" game object via tag
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //Sets a target position to the player's position
        target = new Vector2(player.position.x , player.position.y);

        scene = SceneManager.GetActiveScene();

    }

    private void FixedUpdate()
    {
        //Shoots projectile
        project();

        //Destroys the projectile after a time period
        Object.Destroy(gameObject, 10f);
    }


    //Checks for a collision with the player or another bullet and destroys it
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
            //Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Bullet")
        {
            // Instantiate(impactEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            // Instantiate(impactEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            // Instantiate(impactEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }

    //This adds a force to the projectile in order to move towards the target position
    void project()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
