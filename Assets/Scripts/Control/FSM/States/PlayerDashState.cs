using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerBaseState
{
    public float dashDistance;
    public float dashTime;

    private float _curDashDuration;
    private int _dir;
    private float _cd=0.2f;
    public override E_PlayerStates StateID => E_PlayerStates.Dash;


    private void Update()
    {
        _cd -= Time.deltaTime;
    }

    public override bool DoReason()
    {
        return (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))&& _cd<=0;
    }

    public override void OnEnter()
    {
        if (Input.GetKey(KeyCode.A))
            _dir = -1;
        else if (Input.GetKey(KeyCode.D))
            _dir = 1;

        fsm.animator.Play("DashStart");
        _curDashDuration = 0;
        _cd = 0.2f;
    }


    public override void OnUpdate()
    {
        if (_curDashDuration > dashTime)
        {
            EndState();
        }
        if (fsm.animator.IsAnimFinished("DashStart"))
        {
            fsm.animator.Play("Dash");
        }
        if (fsm.animator.GetCurrentAnimatorStateInfo(0).IsName("Dash"))
        {
            fsm.controller.MoveTowards(dashDistance / dashTime, _dir);
        }
        _curDashDuration += Time.deltaTime;
    }

    public override void OnExit()
    {
        fsm.controller.Stop();
    }
}
