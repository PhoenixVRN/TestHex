using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindingWay : MonoBehaviour
{
    public string name;
    public void OnTriggerStay(Collider other)
    {
        Debug.Log(name);
    }
}
