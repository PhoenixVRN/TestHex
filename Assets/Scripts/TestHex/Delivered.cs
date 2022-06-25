using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivered : MonoBehaviour
{
  
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Auto")
        {
            Debug.Log("Cargo out");
            Destroy(other.GetComponent<TruckManager>().cargoitem.transform.GetChild(0).gameObject);
        }
    }
}
