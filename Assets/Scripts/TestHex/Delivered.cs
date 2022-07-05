using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Delivered : MonoBehaviour
{
    [Header("Имя что нужно доставить")]
    public string itemNeeded;

    [Header("Имя что нужно доставить")]
    public Transform item;

    private float _duration = 5;
    
    void Start()
    {
         transform.DOLocalRotate(new Vector3(0, 360, 0), _duration, RotateMode.FastBeyond360).SetRelative(true).SetLoops(-1)
             .SetEase(Ease.Linear);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Auto" && other.GetComponent<TruckManager>().itemCargo.name == itemNeeded)
        {
//            Debug.Log("Cargo out");
            Destroy(other.GetComponent<TruckManager>().cargoitem.transform.GetChild(0).gameObject);
            
            // TODO пеосылка доставленна
            
            Destroy(gameObject);
        }
    }
}
