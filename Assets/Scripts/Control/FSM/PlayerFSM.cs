using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerFSM : MonoBehaviour
{
    [Header("属性")]
    public float energy;
    //有些状态结束后但动画没有播完,以此为判断
    [ReadOnly] public bool isAnimFinish;

    [Header("相关组件")]
    public Animator animator;
    public CharacterController2D controller;

    [Header("状态机相关")]
    public Transform statesRoot;
    public Dictionary<E_PlayerStates, PlayerBaseState> statesDic
        =new Dictionary<E_PlayerStates, PlayerBaseState>();

    [ShowInInspector,DisplayAsString]
    public E_PlayerStates CurrentState { get; private set; }
    [ShowInInspector, DisplayAsString]
    public E_PlayerStates LastState { get; private set;}

    public CombatData combatData;

    void Start()
    {
        GetRelatedCompoents();
        RegistAllAbilities();
        CurrentState = E_PlayerStates.Idle;
    }

    private void RegistAllAbilities()
    {
        if (statesRoot == null) { Debug.LogError("请设置玩家状态的载体;"); }
        PlayerBaseState[] states = statesRoot.GetComponents<PlayerBaseState>();
        foreach (var item in states)
        {
            if (statesDic.ContainsKey(item.StateID))
            {
                Debug.LogError("添加了相同的状态！"); return;
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
        if (combatData.isDead)
            return;
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
        Debug.LogError("尝试获取不存在的状态");
        return null;
    }
}
