using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Random;

public class SpawnCube : MonoBehaviour
{
    [SerializeField] private GameObject _enamy;
    [SerializeField] private GameObject _experience;
    public static float Speed;
    
    void Start()
    {
        Speed = 2;
        StartCoroutine(SpawnCubes());
    }

   
    void Update()
    {
        
    }

   private IEnumerator SpawnCubes()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            int choice = (Random.Range(0, 2));
            float x = (Random.Range(-50, 50));
            x = x / 100;
            Debug.Log(x.ToString() + "  " + choice.ToString());
            if (choice == 0) Instantiate(_enamy, new Vector3(x, 0.1f, 2), Quaternion.identity);
            else Instantiate(_experience, new Vector3(x, 0.1f, 2), Quaternion.identity);
        }
    }
   
}
