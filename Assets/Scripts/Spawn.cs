using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //Spawns the zone around the player (Was supposed to be used for an arrow)
    public GameObject zone;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(zone, new Vector3(cursorPos.x, cursorPos.y, 0), Quaternion.identity);
        }
    }
}
