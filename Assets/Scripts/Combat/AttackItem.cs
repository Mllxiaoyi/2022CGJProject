using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackItem : MonoBehaviour
{

    public CombatData user;
    public List<CombatData> touchEnemyArr;
    // Start is called before the first frame update
    public void init()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //var role = collision.transform.parent;
        //Debug.Log(role.name);
        //if (role)
        //{
        //    var combatData = role.GetComponent<CombatData>();
        //    if (combatData)
        //    {
        //        if (touchEnemyArr.Contains(combatData))
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            touchEnemyArr.Add(combatData);
        //            combatData.attackThisArr.Add(this);
        //        }
        //    }
        //}
        //Debug.Log(collision.name);
        //if (collision.tag == "attackRange")
        //{
        //    if (animator.GetCurrentAnimatorStateInfo(0).IsName("Block"))
        //    {
        //        var role = collision.transform.parent;
        //        Debug.Log(role.name);
        //        if (role.GetComponent<CombatData>().isCanBePerfectTrick)
        //        {
        //            Debug.Log("������");
        //            power++;
        //            texPower.text = "����ֵ��" + power;
        //        }
        //        else
        //        {
        //            Debug.Log("��ͨ��");
        //            jiaShiTiao--;
        //            texHp.text = "����ֵ��" + jiaShiTiao;
        //        }
        //    }
        //    else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Dash"))
        //    {
        //        var role = collision.transform.parent;
        //        if (role.GetComponent<CombatData>().isCanBePerfectTrick)
        //        {
        //            Debug.Log("��������");
        //            power++;
        //            texPower.text = "����ֵ��" + power;
        //        }
        //    }
        //    else
        //    {
        //        Debug.Log("��ͨ�ܻ�");
        //        jiaShiTiao -= 2;
        //        texHp.text = "����ֵ��" + jiaShiTiao;
        //    }
        //}


    }

}
