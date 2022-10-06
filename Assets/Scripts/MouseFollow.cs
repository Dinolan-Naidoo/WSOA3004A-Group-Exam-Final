using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    //Variables for mouse following
    private float Offset = -0.8f;
    private Vector3 TemporaryPos;
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Offset); // This transforms the position to the new Vector 3 with the offset as z.
        Cursor.lockState = CursorLockMode.Confined; // keep confined in the game window
    }

    void Update()
    {
        //Follows the mouse movement 
        TemporaryPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

        //Temporary Position of the Vector 3 magnitude and direction
        transform.position = new Vector3(TemporaryPos.x, TemporaryPos.y, Offset);
    }
}
