using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExecutedState : PlayerBaseState
{
    public override E_PlayerStates StateID => E_PlayerStates.Executed;
<<<<<<< Updated upstream
=======

    public override void OnEnter()
    {
        fsm.animator.Play("Dead");
    }
>>>>>>> Stashed changes
}
