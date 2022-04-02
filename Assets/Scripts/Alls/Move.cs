using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
  
    void Start()
    {
        StartCoroutine(MoveCubes());
    }

   
    IEnumerator MoveCubes()
    {
        gameObject.GetComponent<Rigidbody>().velocity = -transform.forward * SpawnCube.Speed;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
