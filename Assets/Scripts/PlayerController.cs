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
    private Rigidbody2D rB; //Reference to rigidbody 2d  
    private float currentdistance; //Current distance of mouse drag
    private float safeSpace; // Exists within current distance and max distance
    public float shootpower; // The power that the player can be propelled 
    private Vector3 shootDirection; // The direction vector that the player is being moved to 
    public float maxdistance = 2f; // Max distance of mouse drag

    //Variables for timer 
    private float count = 5f;
    public Slider timerSlider;
    private float coinCount = 0;
    public Camera cam;

    private Scene scene;

    public AudioSource backgroundMusic;

    private bool notPaused = true;

    private void Awake()
    {
        mousePointA = GameObject.FindGameObjectWithTag("PointA");  //Finds point A
        mousePointB = GameObject.FindGameObjectWithTag("PointB");  //Finds point B
        mousePointB.SetActive(false);                              //Removes the mouse point B
        playerColliders = GetComponent<CircleCollider2D>();        //Gets the player collider
        rB = GetComponent<Rigidbody2D>();                          //Gets the player rigidbody
        timerSlider.gameObject.SetActive(false);                   //Disables the timer slider for slow motion time
        timerSlider.value = 1f;                                    //Sets the timer slider to its max value

        scene = SceneManager.GetActiveScene();
        //backgroundMusic.Play();
    }


    private void Update()
    {
        if (coinCount == 3f)
        {
            Debug.Log("WIN");
            if(scene.name == "SampleScene")
            {
                SceneManager.LoadScene("YouWin");
            }
            if (scene.name == "Level2_2")
            {
                SceneManager.LoadScene("YouWin2");
            }

        }

        if (Input.GetMouseButton(0))
        {
            rB.constraints = RigidbodyConstraints2D.FreezeRotation;
            //The following handles the count down of the timer slider and makes the game move in slow motion
            if (timerSlider.value > 0)
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
                if (notPaused)
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
        if (collision.gameObject.tag == "Trigger1")
        {
            rB.constraints = RigidbodyConstraints2D.FreezeAll;

            //cam.orthographicSize = 30;
            

        }
        if (collision.gameObject.tag == "Trigger2")
        {
            //rB.constraints = RigidbodyConstraints2D.FreezeAll;

            //cam.orthographicSize = 19;

            //transform.Rotate(0, 0, -90);


        }

    }

    //The following function checks for a collision with an enemy or enemy bullet and destroys the player
    private void OnCollisionEnter2D(Collision2D collision)
    {

    
            if (collision.gameObject.tag == "Obstacle")
            {

                if(scene.name =="Level1")
                {
                   SceneManager.LoadScene("Level1Retry");
                }

                if (scene.name == "Level2")
                {
                    SceneManager.LoadScene("Level2Retry");
                }
                if (scene.name == "Level2_2")
                {
                    SceneManager.LoadScene("Level2_2Retry");
                }

                if (scene.name == "Level3")
                {
                    SceneManager.LoadScene("Level3_Retry");
                }


             }
       

      


        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Laser")
        {

            if (scene.name == "SampleScene")
            {
                SceneManager.LoadScene("Level1_1Retry");
            }

            if (scene.name == "Level2_2")
            {
                SceneManager.LoadScene("Level2_2Retry");
            }

            if (scene.name == "Level3")
            {
                SceneManager.LoadScene("Level3_Retry");
            }

        }

    }

    public void PausePlayer(bool pause)
    {
        //Vector3 pauseShootDirection = shootDirection;

        if (pause)
        {
            notPaused = false;
            Time.timeScale = 0f;
            //shootpower = 0f;
            //pauseShootDirection = shootDirection;
        }
        else
        {
            notPaused = true;
            Time.timeScale = 1f;
            shootpower = 0f;
            //shootDirection = pauseShootDirection;
        }
    }
}
