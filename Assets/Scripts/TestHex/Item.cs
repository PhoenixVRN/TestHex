using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string name;
    public Transform item;
   
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Auto")
        {
            Debug.Log("Cargo in");
            item.localScale = new Vector3(2f, 2f, 2f);
            item.SetParent(other.GetComponent<TruckManager>().cargoitem.transform);
            item.localPosition = new Vector3(0, 0f, 0);
        }
    }
}
