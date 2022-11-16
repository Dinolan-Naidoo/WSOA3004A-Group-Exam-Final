using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject mouseAnimation;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            mouseAnimation.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

   
}
