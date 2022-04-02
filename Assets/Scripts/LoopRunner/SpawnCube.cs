using System.Collections;
using UnityEngine;


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
    private IEnumerator SpawnCubes()
    {
        while (true)
        {
            yield return new WaitForSeconds(RandomFloat(50, 200));
            int choice = (Random.Range(0, 2));
            if (choice == 0) Instantiate(_enamy, new Vector3(RandomFloat( -50, 50), 0.1f, 2), Quaternion.identity);
            else Instantiate(_experience, new Vector3(RandomFloat( -50, 50), 0.1f, 2), Quaternion.identity);
        }
    }

   private float RandomFloat(int min, int max)
   {
       float x = (Random.Range(min, max));
       return x = x / 100;
   }
   
}
