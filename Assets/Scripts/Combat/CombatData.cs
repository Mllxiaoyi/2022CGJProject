using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


using UnityEngine.Events;
using TMPro;
public class CombatData : MonoBehaviour, IDamageable
{
    public int jiaShiTiao;
    public int energy;
    private Animator _animator;

    public TMP_Text hpText;

    public GameObject diedFX;

    public UnityEvent OnHited;
    public UnityEvent OnDamaged;
    public UnityEvent OnDied;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }


    private void LateUpdate()
    {
        hpText.text = jiaShiTiao.ToString();

    }

    void IDamageable.OnHited()
    {
        OnHited?.Invoke();

        //if (animator.GetCurrentAnimatorStateInfo(0).IsName("Block")) { return; }
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("PerfectBlock"))
        {
            Debug.Log("完美格挡");

        }
        else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Block"))
        {
            Debug.Log("普通格挡");
            jiaShiTiao--;
            OnDamaged?.Invoke();
        }
        else
        {
            jiaShiTiao -= 2;
            OnDamaged?.Invoke();
        }

        if (jiaShiTiao <= 0)
        {
            OnDied?.Invoke();
            this.tag = "Untagged";
            return;
        }

    }
}