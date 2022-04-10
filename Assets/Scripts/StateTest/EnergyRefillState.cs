using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class EnergyRefillState : State
{
    private Transform targetBed;

    private Vector3 lastCharPos;

    private bool isSleepStart;
    private float sleepTimerLeft = 2f;

    public override void Init()
    {
        targetBed = GameObject.FindGameObjectWithTag("Bad").transform;
    }
    public override void Run()
    {
        if (isFinished)
            return;
        if (!isSleepStart)
            MoveToBed();
        else
            DoSleep();
    }

    void MoveToBed()
    {
        var distance = (targetBed.position - character.transform.position).magnitude;

        if (distance > 1f)
        {
            character.MoveTo(targetBed.position);
        }
        else
        {
            lastCharPos = character.transform.position;
            character.transform.position = targetBed.position;

            isSleepStart = true;
        }
    }

    void DoSleep()
    {
        sleepTimerLeft -= Time.deltaTime;
        
        if (sleepTimerLeft >0)
            return;
        character.transform.position = lastCharPos;
        character.energy = 2f;
        isFinished = true;
    }
    
}
