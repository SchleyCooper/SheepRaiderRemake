using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine<T>
{
    protected T owner;

    protected State<T> currentState;

    public StateMachine(T _owner)
    {
        owner = _owner;
    }

    public void Initialize(T _owner, State<T> startingState)
    {
        currentState = startingState;
        currentState.Enter(owner);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void UpdateLogic(T owner)
    {
        if (currentState != null)
            currentState.LogicUpdate(owner);
    }

    void UpdatePhysics(T owner)
    {
        if (currentState != null)
            currentState.PhysicsUpdate(owner);
    }

    public void ChangeState(State<T> newState)
    {
        if (currentState != null)
            currentState.Exit(owner);

        currentState = newState;

        if (currentState != null)
            currentState.Enter(owner);
    }

}
