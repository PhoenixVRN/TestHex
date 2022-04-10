using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu (menuName = "State", fileName = "Eat State")]
public class EatState : State
{
    public float restoresEat = 06f;
    public State noApplesState;  //  стотояние если яблок нет!

    private Transform taretApple;

    public override void Init()
    {
        var apples = GameObject.FindGameObjectsWithTag("Apple");
        if (apples.Length == 0)
        {
            character.SetState(noApplesState); // перерход в стотояние если яблок нет!
            return;
        }

        taretApple = apples[Random.Range(0, apples.Length)].transform;
    }
   
    public override void Run()
    {
        if (isFinished)
            return;
        MoveToApple();
    }

    void MoveToApple()
    {
        var distance = (taretApple.position - character.transform.position).magnitude;

        if (distance > 1f)
        {
            character.MoveTo(taretApple.position);
        }
        else
        {
            Destroy((taretApple.gameObject));
            character.eat += restoresEat;
            isFinished = true;
        }
    }
}
