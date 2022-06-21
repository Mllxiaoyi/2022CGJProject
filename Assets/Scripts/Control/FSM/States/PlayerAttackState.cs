using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public override E_PlayerStates StateID => E_PlayerStates.Attack;

    public override bool DoReason()
    {
        return Input.GetMouseButtonDown(0);
    }

    public override void OnEnter()
    {
        if (fsm.energy>=2)
        {
            fsm.animator.Play("HeavyAttack");
        }
        else
        {
            fsm.animator.Play("Attack");
        }
        
    }

    public override void OnUpdate()
    {
        if (fsm.animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            EndState();
        }
    }
}
