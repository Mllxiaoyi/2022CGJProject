using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlockState : PlayerBaseState
{
    public override E_PlayerStates StateID => E_PlayerStates.Block;
    public override bool CanTranslateRepeatly => true;

    private bool isDuringAnimFinish;
    public override bool DoReason()
    {
        return Input.GetMouseButtonDown(1);
    }
    public override void OnEnter()
    {
        fsm.animator.Play("Block");
    }

    public override void OnUpdate()
    {
        if (Input.GetMouseButtonUp(1))
        {
            isDuringAnimFinish = true;
            fsm.animator.SetTrigger("BlockRelease");
            EndState();
        }
        
        //��ȡ���񵲵Ĺ��������ܿ��ƿ�ʼ��
        fsm.TryEnterTargetState(E_PlayerStates.Block);
    }
}
