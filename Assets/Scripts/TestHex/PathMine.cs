using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathMine : MonoBehaviour
{
    [SerializeField] private float rayDistance = 0.35f;
    [SerializeField] private GameObject _startButton; 
    [SerializeField]  private int _speedTruck;
    [SerializeField]  private AudioSource _startAudioTruck;
    [SerializeField]  private AudioSource _failAudioTruck;
    
    
    [HideInInspector] public Vector3[] waypoints;
    
    public Transform startPosition;
    public PathType pathType = PathType.CatmullRom;
   


    private List<Vector3> _pointList = new List<Vector3>();
    private RaycastHit hit;
    private bool _nextPoint = true;
    private Transform target;
    private Vector3 _lastPos;
    private bool _isMove;


    void Start()
    {
        _isMove = false;
        target = startPosition;
        _lastPos = transform.position;
    }

    private void Update()
    {
      //  if (_isMove) ChecMove();
    }

    public void SetWaypoints()
    {
        StartCoroutine(StartTruck());
    }

    IEnumerator StartTruck()
    {
        _startAudioTruck.Play();
        yield return new WaitForSeconds(1.5f);
        _startButton.SetActive(false);
        BuildingPath();
        waypoints = _pointList.ToArray();
        
        Tween t = target.DOPath(waypoints, _speedTruck, pathType)
            .SetOptions(false)
            .SetLookAt(0.01f);
        t.SetSpeedBased(true);
        t.SetEase(Ease.Linear).SetLoops(0);
        
        yield return new WaitForSeconds(1.5f);
        _isMove = true;
        StartCoroutine(ChecMoveng());
    }
    
    

    public void BuildingPath()
    {
        var point = startPosition.transform.gameObject;

        while (_nextPoint)
        {
            Ray ray = new Ray(point.transform.position, LocalInWorld(point));

            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                Debug.DrawRay(ray.origin, ray.direction, Color.red, 1);
                if (hit.collider.gameObject.tag == "RoadPoint")
                {
                    _pointList.Add(hit.transform.position);            
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
        var v1 = pos.transform.localToWorldMatrix.MultiplyPoint(Vector3.forward);
        var v0 = pos.transform.localToWorldMatrix.MultiplyPoint(Vector3.zero);
        Vector3 dir = v1 - v0;
        return dir;
    }

    IEnumerator ChecMoveng()
    {
        while (_isMove)
        {
            yield return new WaitForSeconds(0.2f);
            if (_lastPos == transform.position)
            {
                _isMove = false;
                _startAudioTruck.Stop();
                _failAudioTruck.Play();
 //               StartCoroutine(Restart());
            }
            else
            {
                _lastPos = transform.position;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }
    private void ChecMove()
    {
        if (_lastPos == transform.position)
        {
            _isMove = false;
            _startAudioTruck.Stop();
            _failAudioTruck.Play();
            StartCoroutine(Restart());
        }
        else
        {
            _lastPos = transform.position;
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
