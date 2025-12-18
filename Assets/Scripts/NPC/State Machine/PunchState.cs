using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchState : IState
{
    private NPC _npc;

    public NPCStateType StateType => NPCStateType.Punch;


    public PunchState(NPC npc)
    {
        _npc = npc;
    }

    public void Enter()
    {
        _npc.ChangeAnim(AnimParams.NPC_PUNCHING);
    }

    public void Update()
    {

    }

    public void Exit()
    {
        
    }
}
