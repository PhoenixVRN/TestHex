using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    private RaycastHit hit;
 //   private RaycastHit entiti;
    public Transform pointer;
    public Transform startPosition;
    public float rayDistance;

    private bool _nextPoint;
    void Start()
    {
        
    }

   
    void Update()
    {
//        var entiti;
//        var hit = Physics.Raycast(transform.position, transform.localScale, rayDistance, out entiti);
//        Ray ray = new Ray(transform.position, transform.right);
//        Debug.DrawRay(transform.position, transform.right, Color.red);

        /*if (Physics.Raycast(ray, out hit, rayDistance))
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 1);
            pointer.position = hit.point;
            Debug.Log(hit.collider.gameObject.tag);
        }*/
    }

    public void BuildingPath()
    {
        while (_nextPoint)
        {
            Ray ray = new Ray(transform.position, transform.right);

            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                if (hit.collider.gameObject.tag == "RoadPoint")
                {
                    
                }
            }
        }
    }
}
