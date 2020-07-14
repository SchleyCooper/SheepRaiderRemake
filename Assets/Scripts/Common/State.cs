using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<T>
{
    public abstract void Enter(T owner);

    public abstract void LogicUpdate(T owner);

    public abstract void PhysicsUpdate(T owner);

    public abstract void Exit(T owner);
}
