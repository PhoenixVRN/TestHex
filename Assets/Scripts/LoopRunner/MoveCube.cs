using UnityEngine;

public class MoveCube : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(-Vector3.forward * SpawnCube.Speed * Time.deltaTime);
    }
}
