using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PathMine : MonoBehaviour
{
    public Transform target;
    public PathType pathType = PathType.CatmullRom;
    public Vector3[] waypoints;
    List<Vector3> count = new List<Vector3>();
    private int _duration;
   
    void Start()
    {
        SetWaypoints();
        Tween t = target.DOPath(waypoints, _duration, pathType)
            .SetOptions(false)
            .SetLookAt(0.001f);
        t.SetEase(Ease.Linear).SetLoops(0);
    }

    private void SetWaypoints()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Road");
        foreach (var e in enemies)
        {
            count.Add(e.transform.position);
        }
        _duration = enemies.Length;
        waypoints = count.ToArray();
    }
    
}
