using UnityEngine;

public class Timer : MonoBehaviour
{
    [HideInInspector] public float timer;
    private int _sec;
    private int _min;
   
    void Start()
    {
        timer = 0;
        _sec = 0;
        _min = 0;
    }

  
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer > 1)
        {
            timer = 0;
            _sec++;
        }
        if (_sec > 60)
        {
            _sec = 0;
            _min++;
        }
    }

    public void StartTimer()
    {
        timer = 0;
        _sec = 0;
        _min = 0;
    }

    public string TimerText()
    {
        var x = _min.ToString() + ":" + _sec.ToString();
        return x;
    }
}
