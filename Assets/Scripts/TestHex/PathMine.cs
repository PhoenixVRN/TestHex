using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PathMine : MonoBehaviour
{
    [SerializeField] private float rayDistance = 1f;

    public Transform startPosition;
    public Transform target;
    public PathType pathType = PathType.CatmullRom;
    public Vector3[] waypoints;
//    public Transform test;

    private List<Vector3> _pointList = new List<Vector3>();
    private int _duration;
    private RaycastHit hit;
    private bool _nextPoint = true;


    void Start()
    {
        
    }

    private void Update()
    {
 //       Detected();
    }

    public void DebugingDrow()
    {
        
    }

    public void SetWaypoints()
    {
        /*GameObject[] enemies = GameObject.FindGameObjectsWithTag("Road");
        foreach (var e in enemies)
        {
            _pointList.Add(e.transform.position);
        }*/
        BuildingPath();
        _duration = _pointList.Count;
        waypoints = _pointList.ToArray();
        
        Debug.Log(_duration.ToString());
        Tween t = target.DOPath(waypoints, _duration, pathType)
            .SetOptions(false)
            .SetLookAt(0.001f);
        t.SetEase(Ease.Linear).SetLoops(0);
    }
    
    

    public void BuildingPath()
    {
//        var nextPosition = startPosition.transform.position;
        var point = startPosition.transform.gameObject;

        while (_nextPoint)
        {
            Ray ray = new Ray(point.transform.position, LocalInWorld(point));

            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                Debug.DrawRay(ray.origin, ray.direction, Color.red, 1);
                if (hit.collider.gameObject.tag == "RoadPoint")
                {
//                    Debug.Log("Наши точку");
//                    var pos = transform.position;
                    _pointList.Add(hit.transform.position);
//                    nextPosition = hit.transform.position;
                    point = hit.transform.gameObject;
                }
                else
                {
                    _nextPoint = false;
                }
            }
            else
            {
                _nextPoint = false;
            }
        }
    }

    public Vector3 LocalInWorld(GameObject pos)
    {
        var v1 = pos.transform.localToWorldMatrix.MultiplyPoint(Vector3.right);
        var v0 = pos.transform.localToWorldMatrix.MultiplyPoint(Vector3.zero);
        Vector3 dir = v1 - v0;
        return dir;
    }
    
    /*public void Detected()
    {
        var nextPosition = test.transform.position;
        
        var V1 = test.transform.localToWorldMatrix.MultiplyPoint(Vector3.right);
        var V0 = test.transform.localToWorldMatrix.MultiplyPoint(Vector3.zero);
        
        Ray ray = new Ray(nextPosition, V1-V0);
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.red);
            if (hit.collider.gameObject.tag == "RoadPoint")
            {
                Debug.Log("Наши точку");
               _pointList.Add(hit.transform.position);
                nextPosition = hit.transform.position;
            }
        }
    }*/
}
