using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public float attackMoveSpeed;
    [Tooltip("攻击时位移的时间,最长不超过攻击动画的时间")]
    public float attackMoveDuration=100;

    private float _curDuration;
    public override E_PlayerStates StateID => E_PlayerStates.Attack;

    public override bool DoReason()
    {
        return Input.GetMouseButtonDown(0)||InputManager.Instance.ReadCachedKey(KeyCode.Mouse0);
    }

    public override void OnEnter()
    {
        if (fsm.combatData.enemyRole.jiaShiTiao <= 0)
        {
            fsm.animator.Play("HeavyAttack");
        }
        else
        {
            if (fsm.GetComponent<CombatData>().power >= 2)
            {
                fsm.animator.Play("HeavyAttack");
                fsm.combatData.isBigAttack = true;
                fsm.combatData.changePower(-9999);
            }
            else
            {
                fsm.animator.Play("Attack");
            }
        }

        _curDuration = 0;
        fsm.controller.FaceTo(1);                   //朝右
    }

    public override void OnUpdate()
    {
        if (fsm.animator.GetCurrentAnimatorStateInfo(0).IsName("Hited"))
        {
            fsm.ChangeState(E_PlayerStates.Hited);
        }
       else if (fsm.animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            EndState();
        }
        _curDuration += Time.deltaTime;
        if (_curDuration<= attackMoveDuration)
        {
            fsm.controller.MoveForward(attackMoveSpeed);
        }
        else
        {
            fsm.controller.Stop();
        }
    }
}
