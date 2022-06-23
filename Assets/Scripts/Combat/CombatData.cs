using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatData : MonoBehaviour
{
    public int jiaShiTiao;
    public Animator animator;

    public bool isPerfectDefence;

    public GameObject diedFX;
    private void LateUpdate()
    {
        if (jiaShiTiao<=0)
        {
            Instantiate<GameObject>(diedFX, this.transform.position, Quaternion.identity).SetActive(true);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tag == "Player") { return; }

        //if (animator.GetCurrentAnimatorStateInfo(0).IsName("Block")) { return; }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("PerfectBlock"))
        {
            Debug.Log("完美格挡");
            isPerfectDefence = false;
        }
        else if(animator.GetCurrentAnimatorStateInfo(0).IsName("Block"))
        {
            Debug.Log("普通格挡");
            jiaShiTiao--;
        }
        else
        {
            jiaShiTiao -= 2;
        }
        
    }
}
