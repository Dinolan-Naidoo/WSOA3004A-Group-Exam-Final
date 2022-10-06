using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    //Variables for movement
    private GameObject mousePointA; //Reference to distance point A
    private GameObject mousePointB; //Reference to distance point B
    private CircleCollider2D playerColliders; // Reference to colliders
    private Rigidbody2D rB; //Reference to rigidbody
    private float currentdistance; //Current distance of mouse drag
    private float safeSpace; // Exists within current distance and max distance
    private float shootpower; // The power that the player can be propelled 
    private Vector3 shootDirection; // The direction vector that the player is being moved to 
    public float maxdistance = 2f; // Max distance of mouse drag

    //Variables for timer 
    private float count = 5f;
    public Slider timerSlider;
    private float coinCount = 0;

    private void Awake()
    {
        mousePointA = GameObject.FindGameObjectWithTag("PointA");  //Finds point A
        mousePointB = GameObject.FindGameObjectWithTag("PointB");  //Finds point B
        mousePointB.SetActive(false);                              //Removes the mouse point B
        playerColliders = GetComponent<CircleCollider2D>();        //Gets the player collider
        rB = GetComponent<Rigidbody2D>();                          //Gets the player rigidbody
        timerSlider.gameObject.SetActive(false);                   //Disables the timer slider for slow motion time
        timerSlider.value = 1f;                                    //Sets the timer slider to its max value
    }


    private void Update()
    {
        if (coinCount == 3f)
        {
            Debug.Log("WIN");
            SceneManager.LoadScene("YouWin");
        }
        if (Input.GetMouseButton(0))
        {

            //The following handles the count down of the timer slider and makes the game move in slow motion
               if(timerSlider.value > 0)
               {
                mousePointB.SetActive(true);
                Time.timeScale = 0.1f;
                Time.fixedDeltaTime = Time.timeScale * 0.02f;
                currentdistance = Vector3.Distance(mousePointA.transform.position, transform.position);
                currentdistance = Mathf.Abs(2f);
                count -= 10 * Time.deltaTime;
                timerSlider.gameObject.SetActive(true);
                timerSlider.value -= (3 * Time.deltaTime);
               }
               else
               {
                Time.timeScale = 1f;      //Game speed resumes to normal
               }
                


               //The following keeps the mouse control movement within a range
            if (currentdistance <= maxdistance)
            {
                safeSpace = currentdistance;
            }

            else
            {
                safeSpace = maxdistance;
            }

                //Power of player projection 
                shootpower = Mathf.Abs(safeSpace) * 16f;
                Vector3 Dxy = mousePointA.transform.position - transform.position;
                float difference = Dxy.magnitude;
                mousePointB.transform.position = transform.position + ((Dxy / difference) * currentdistance * -1);
                mousePointB.transform.position = new Vector3(mousePointB.transform.position.x, mousePointB.transform.position.y, -1.5f);

                //Direction of splayer projection
                shootDirection = Vector3.Normalize(mousePointA.transform.position - transform.position);
        }

            //Handles the player movement when the left click is released
            if (Input.GetMouseButtonUp(0))
            {
                Time.timeScale = 1;
                Vector3 push = shootDirection * shootpower * -1f;
                rB.velocity = push;
                mousePointB.SetActive(false);
                //countdownT.gameObject.SetActive(false);
                count = 5f;
                timerSlider.value = 1f;
                timerSlider.gameObject.SetActive(false);
            }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("QUIT");
        }

    }

    //The following function checks for a collision with a coin and updates the coin score
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.tag == "Coin")
         {
            if (coinCount < 3)
            {
                coinCount = coinCount + 1;
                Debug.Log(coinCount);
            }
         }
    }

    //The following function checks for a collision with an enemy or enemy bullet and destroys the player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Bullet" || collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
  
    }
}
