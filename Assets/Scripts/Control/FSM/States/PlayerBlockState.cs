using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlockState : PlayerBaseState
{
    public override E_PlayerStates StateID => E_PlayerStates.Block;
    public override bool CanTranslateRepeatly => true;

    public float blockMoveSpeed;
    public float blockMoveDuration = 0.5f;

    public float curDuration;
    //�������״̬,��Ҫ��Щ�޸�
    public override bool DoReason()
    {
        return Input.GetMouseButtonDown(1)||InputManager.Instance.ReadCachedKey(KeyCode.Mouse0);
    }
    public override void OnEnter()
    {
        fsm.animator.Play("Block");
        fsm.combatData.Block();
        curDuration = 99999;

    }

    public override void OnUpdate()
    {
        if (Input.GetMouseButtonUp(1))
        {
            fsm.animator.SetTrigger("BlockRelease");
            EndState();
        }
        //Debug.Log(curDuration);
        curDuration += Time.deltaTime;
        if (curDuration <= blockMoveDuration)
        {
            fsm.controller.MoveBackward(blockMoveSpeed);
        }
        else
        {
            fsm.controller.Stop();
        }
        //��ȡ���񵲵Ĺ��������ܿ��ƿ�ʼ��
        //fsm.TryEnterTargetState(E_PlayerStates.Block);
    }
}
