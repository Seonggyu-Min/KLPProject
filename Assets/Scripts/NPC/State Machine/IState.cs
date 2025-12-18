using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public NPCStateType StateType { get; }

    public void Enter();
    public void Update();
    public void Exit();
}
