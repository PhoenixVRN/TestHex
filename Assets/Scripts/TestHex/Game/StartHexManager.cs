using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHexManager : MonoBehaviour
{
    public static StartHexManager Instance;
    
    [SerializeField] private GameObject _prefabTruck;
    private PathMine _truck;

    [SerializeField] private PathMine _pathMine;

    private void Awake()
    {
        if (Instance) Destroy(gameObject);
        else Instance = this;
        CreateTruck();
    }
    
    public void GoTruck()
    {
        _truck.SetWaypoints();
    }
    
    public void RestartTruck()
    {
        _truck.Restart();
        CreateTruck();
    }

    private void CreateTruck()
    {
        if (_prefabTruck != null)
        {
            var pos = gameObject.transform.position;
            var truck = Instantiate(_prefabTruck, new Vector3(0.36f + pos.x, 0.3f + pos.y, -0.1f + pos.z), Quaternion.Euler(0, 90, 0));
            truck.transform.SetParent(gameObject.transform);
            _truck = truck.GetComponent<PathMine>();
        }
    }
}
