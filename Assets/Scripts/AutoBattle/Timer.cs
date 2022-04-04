using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [HideInInspector] public float timer;
    private int sec;
    private int min;
   
    void Start()
    {
        timer = 0;
        sec = 0;
        min = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer > 1)
        {
            timer = 0;
            sec++;
        }
        if (sec > 60)
        {
            sec = 0;
            min++;
        }
    }

    public void StartTimer()
    {
        timer = 0;
        sec = 0;
        min = 0;
    }

    public string TimerText()
    {
        var x = min.ToString() + ":" + sec.ToString();
        return x;
    }
}
