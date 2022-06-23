using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlockState : PlayerBaseState
{
    public override E_PlayerStates StateID => E_PlayerStates.Block;
    public override bool CanTranslateRepeatly => true;

    //�������״̬,��Ҫ��Щ�޸�
    public override bool DoReason()
    {
        return Input.GetMouseButtonDown(1)||InputManager.Instance.ReadCachedKey(KeyCode.Mouse0);
    }
    public override void OnEnter()
    {
        fsm.animator.Play("Block");
    }

    public override void OnUpdate()
    {
        if (Input.GetMouseButtonUp(1))
        {
            fsm.animator.SetTrigger("BlockRelease");
            EndState();
        }

        //��ȡ���񵲵Ĺ��������ܿ��ƿ�ʼ��
        //fsm.TryEnterTargetState(E_PlayerStates.Block);
    }
}
