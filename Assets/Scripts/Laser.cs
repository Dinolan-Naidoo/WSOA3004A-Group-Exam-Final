using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 100;

    public Transform firePoint;
    public LineRenderer lineRenderer;

    Transform transform;
    public GameObject player;

    private void Awake()
    {
        transform = GetComponent<Transform>();
    }

    private void Update()
    {
        ShootLaser();
    }

    void ShootLaser()
    {
        if(Physics2D.Raycast(transform.position,transform.right))
        {
            RaycastHit2D _hit = Physics2D.Raycast(transform.position, transform.right);
            Draw2DRay(firePoint.position, _hit.point);
            if (_hit.collider != null)
            {
                
               // Debug.Log(_hit.collider.name);
                if(_hit.collider.gameObject.tag == "Player")
                {
                    //Destroy(player);
                    SceneManager.LoadScene("Level1Retry");
                }
            }
        }
        else
        {
            Draw2DRay(firePoint.position, firePoint.transform.right * defDistanceRay);
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }

}
