using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private NPC _npc;
    private readonly float _transitionDuration = 3f;
    private float _elapsed;

    public NPCStateType StateType => NPCStateType.Idle;


    public IdleState(NPC npc)
    {
        _npc = npc;
    }

    public void Enter()
    {
        Init();
        _npc.ChangeAnim(AnimParams.NPC_IDLE);
    }

    public void Update()
    {
        _elapsed += Time.deltaTime;
        if (_elapsed >= _transitionDuration)
        {
            _npc.ToYawn();
        }
    }

    public void Exit()
    {
        
    }


    private void Init()
    {
        _elapsed = 0f;
    }
}
