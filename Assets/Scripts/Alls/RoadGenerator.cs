using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _experience;
    [SerializeField] private GameObject _enamy;
    
    public GameObject[] road;
    public bool[] roadNumbers;
    public int currentRoadLength = 0;
    public int maximumRoadLength = 6;
    public string roadGeneratorStatus = "Generator";
    public float distanceBetweenRoads;
    public float speedRoad = 5;
    public float maximumPositionZ = -15;
    public Vector3 waitingZona = new Vector3(0, 0, -40);

    private int _currentRoadNumber = -1;
    private int _lastRoadNumber = -1;
    private List<GameObject> _readyRoad = new List<GameObject>();
    
    void Start()
    {
        
    }

   
    void FixedUpdate()
    {
        if (roadGeneratorStatus == "Generator")
        {
            if (currentRoadLength != maximumRoadLength)
            {
                _currentRoadNumber = Random.Range(0, road.Length);

                if (_currentRoadNumber != _lastRoadNumber)
                {
                    if (_currentRoadNumber < road.Length /2)
                    {
                        if (!roadNumbers[_currentRoadNumber])
                        {
                            if (_lastRoadNumber != (road.Length / 2) + _currentRoadNumber) RoadCreation();
                            else if (_lastRoadNumber == (road.Length / 2) + _currentRoadNumber &&
                                     currentRoadLength == road.Length - 1) RoadCreation();
                           
                        }
                    }
                }
                else if (_currentRoadNumber >= road.Length / 2)
                {
                    if (!roadNumbers[_currentRoadNumber])
                    {
                        if (_lastRoadNumber != _currentRoadNumber - (road.Length / 2)) RoadCreation();
                    }
                    else if (_lastRoadNumber == _currentRoadNumber - (road.Length / 2) && currentRoadLength == road.Length -1) RoadCreation();
                }
            }

            MovingRoad();

            if (_readyRoad.Count != 0)
            {
                RemovingRoad();
            }
        }
    }

    public void MovingRoad()
    {
        foreach (var readyRoad in _readyRoad)
        {
            readyRoad.transform.localPosition -= new Vector3(0, 0, speedRoad * Time.fixedDeltaTime);
        }
    }

    private void RemovingRoad()
    {
        if (_readyRoad[0].transform.localPosition.z < maximumPositionZ)
        {
            int i;
            i = _readyRoad[0].GetComponent<Road>().number;
            roadNumbers[i] = false;
            _readyRoad.RemoveAt(0);
            currentRoadLength--;
        }
    }

    private void RoadCreation()
    {
        if (_readyRoad.Count > 0)
        {
            road[_currentRoadNumber].transform.localPosition = _readyRoad[_readyRoad.Count - 1].transform.position +
                                                               new Vector3(0, 0, distanceBetweenRoads);
//            CreationCubes();
        }
        else if (_readyRoad.Count == 0)
        {
            road[_currentRoadNumber].transform.localPosition = new Vector3(0, 0, 0);
        }

        road[_currentRoadNumber].GetComponent<Road>().number = _currentRoadNumber;
        roadNumbers[_currentRoadNumber] = true;
        _lastRoadNumber = _currentRoadNumber;
        _readyRoad.Add(road[_currentRoadNumber]);
        currentRoadLength++;
       
    }

    private void CreationCubes()
    {
        var x = Random.Range(-20f, 20f) / 100;
        var z = Random.Range(-2, 2);
        var p = Instantiate(_experience, new Vector3(x, 0.07f, z), Quaternion.identity);
        p.transform.SetParent(_readyRoad[_readyRoad.Count - 1].transform);

    }
}
