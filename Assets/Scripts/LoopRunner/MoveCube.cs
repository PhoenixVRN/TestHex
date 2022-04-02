using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
   
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = -transform.forward * SpawnCube.Speed;
    }

    
    void Update()
    {
        
    }
}
