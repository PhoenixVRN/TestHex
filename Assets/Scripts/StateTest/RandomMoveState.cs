using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu]
public class RandomMoveState : State
{
    public float maxDistance = 5f;

    private Vector3 randomPosition;

    public override void Init()
    {
        var randomed = new Vector3(Random.Range(-maxDistance, maxDistance), 0f, Random.Range(-maxDistance, maxDistance));
        randomPosition = character.transform.position + randomed;
    }
    public override void Run()
    {
        var distance = (randomPosition - character.transform.position).magnitude;
        if (distance > 0.5f)
            character.MoveTo(randomPosition);
        else
            isFinished = true;
    }
}


