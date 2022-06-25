using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.BehaviourTrees;

public class Enemy : MonoBehaviour
{
    public BehaviourTreeOwner bt;
    private Animator _animator;
    void Start()
    {
        GetComponent<CombatData>().OnHited.AddListener(TakeHit);
        _animator = GetComponent<Animator>();
    }


    private void TakeHit()
    {
        _animator.Play("Hited");
        bt.PauseBehaviour();
        StartCoroutine(WaitAnimFinish());
    }
    // Update is called once per frame
    IEnumerator WaitAnimFinish()
    {
        yield return new WaitForEndOfFrame();
        while (_animator.IsAnimFinished("Hited"))
        {
            yield return new WaitForEndOfFrame();
        }
        bt.StartBehaviour();
    }
}
