using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YawnState : IState
{
    private NPC _npc;

    public NPCStateType StateType => NPCStateType.Yawn;


    public YawnState(NPC npc)
    {
        _npc = npc;
    }


    public void Enter()
    {
        _npc.ChangeAnim(AnimParams.NPC_YAWN);
    }

    public void Update()
    {

    }

    public void Exit()
    {
        
    }
}
