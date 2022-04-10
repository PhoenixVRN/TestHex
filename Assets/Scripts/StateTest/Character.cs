using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{
    [Header("Initial Parametrs")]
    public float eat = 1f;
    public float energy = 1f;

    public State startState;
    public State eatState;
    public State energyState;
    public State RandomMoveState;

    [Header("Actual state")] public State currentState;

    private float eatEndTime = 15f;
    private float energyEndTime = 15f;
    void Start()
    {
        SetState(startState);
    }

    void Update()
    {
        eat -= Time.deltaTime / eatEndTime;
        energy -= Time.deltaTime / energyEndTime;

        if (!currentState.isFinished)
        {
            currentState.Run();
        }
        else
        {
            if (eat <= 0.4f)
                SetState(eatState);
            else if (energy <= 0.4f)
                SetState(energyState);
            else
                SetState(RandomMoveState);
        }
    }

    public void SetState(State state)
        {
            currentState = Instantiate(state);
            currentState.character = this;
            currentState.Init();
        }

        public  void MoveTo(Vector3 position)
        {
            position.y = transform.position.y;

            transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
                Quaternion.LookRotation(position - transform.position), Time.deltaTime * 120f);
        }
    
}
