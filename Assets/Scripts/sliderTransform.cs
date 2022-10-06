using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliderTransform : MonoBehaviour
{
    //Reference to the player transform
    public Transform plyer;
   
    // Update is called once per frame
    void Update()
    {
        //Follows the player around the level
        transform.position = new Vector3(plyer.transform.position.x , plyer.transform.position.y +1f, 0);
    }
}
