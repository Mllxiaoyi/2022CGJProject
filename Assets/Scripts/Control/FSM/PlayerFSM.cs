using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerFSM : MonoBehaviour
{
    [Header("����")]
    public float energy;
    //��Щ״̬�����󵫶���û�в���,�Դ�Ϊ�ж�
    [ReadOnly] public bool isAnimFinish;

    [Header("������")]
    public Animator animator;
    public CharacterController2D controller;

    [Header("״̬�����")]
    public Transform statesRoot;
    public Dictionary<E_PlayerStates, PlayerBaseState> statesDic
        =new Dictionary<E_PlayerStates, PlayerBaseState>();

    [ShowInInspector,DisplayAsString]
    public E_PlayerStates CurrentState { get; private set; }
    [ShowInInspector, DisplayAsString]
    public E_PlayerStates LastState { get; private set;}

    void Start()
    {
        GetRelatedCompoents();
        RegistAllAbilities();
        CurrentState = E_PlayerStates.Idle;
    }

    private void RegistAllAbilities()
    {
        if (statesRoot == null) { Debug.LogError("���������״̬������;"); }
        PlayerBaseState[] states = statesRoot.GetComponents<PlayerBaseState>();
        foreach (var item in states)
        {
            if (statesDic.ContainsKey(item.StateID))
            {
                Debug.LogError("�������ͬ��״̬��"); return;
            }
            statesDic.Add(item.StateID, item);
            item.Init(this);
        }
    }

    private void GetRelatedCompoents()
    {
        if (!animator) { animator = GetComponent<Animator>(); }
        if (!controller) { controller = GetComponent<CharacterController2D>(); }
    }

    void Update()
    {
        statesDic[CurrentState]?.OnUpdate();
    }


    public void TryEnterTargetState(E_PlayerStates targetState)
    {
        if (statesDic[targetState].DoReason())
        {
            ChangeState(targetState);
        }
    }
    public void ChangeState(E_PlayerStates nextState)
    {
        if (CurrentState == nextState&& !statesDic[CurrentState].CanTranslateRepeatly) return;
        statesDic[CurrentState].OnExit();
        LastState = CurrentState;
        CurrentState = nextState;
        statesDic[CurrentState].OnEnter();
    }

    public PlayerBaseState GetState(E_PlayerStates state)
    {
        if (statesDic.ContainsKey(state))
        {
            return statesDic[state];
        }
        Debug.LogError("���Ի�ȡ�����ڵ�״̬");
        return null;
    }
}
