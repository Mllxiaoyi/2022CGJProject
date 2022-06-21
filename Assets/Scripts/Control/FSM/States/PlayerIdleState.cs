using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override E_PlayerStates StateID => E_PlayerStates.Idle;

    public override void OnUpdate()
    {
        base.OnUpdate();
        fsm.controller.Stop();
        fsm.TryEnterTargetState(E_PlayerStates.Attack);
        fsm.TryEnterTargetState(E_PlayerStates.Block);
        fsm.TryEnterTargetState(E_PlayerStates.Dash);
    }
}
