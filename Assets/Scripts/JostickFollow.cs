using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JostickFollow : MonoBehaviour
{

    GamePadControls control;

    [SerializeField]
    private GameObject Player;

    //Variables for mouse following
    private float Offset = -0.8f;
    private Vector3 TemporaryPos;
    private Vector2 TempPos;

    private void Awake()
    {
        control = new GamePadControls();
        control.Gameplay.Aim.performed += ctx => TempPos = ctx.ReadValue<Vector2>();
        control.Gameplay.Aim.canceled += ctx => TempPos = Player.transform.position;
    }

    private void OnEnable()
    {
        control.Gameplay.Enable();
    }

    private void OnDisable()
    {
        control.Gameplay.Disable();
    }
   
    void Start()
    {
        

        //transform.position = new Vector3(transform.position.x, transform.position.y, Offset); // This transforms the position to the new Vector 3 with the offset as z.
        //Cursor.lockState = CursorLockMode.Confined; // keep confined in the game window
    }

    void Update()
    {

        //Debug.Log(transform.position);
        //Follows the mouse movement 
        //TemporaryPos = Camera.main.ScreenToWorldPoint(new Vector3(TempPos.x, TempPos.y, 10));
        TemporaryPos = new Vector3(TempPos.x, TempPos.y, 10);

        //Temporary Position of the Vector 3 magnitude and direction
        transform.position = new Vector3(TempPos.x, TempPos.y, Offset);


    }
}
