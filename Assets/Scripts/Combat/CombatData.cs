using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatData : MonoBehaviour
{
    public int jiaShiTiao;
    public int power;

    public Animator animator;

    //public bool isPerfectDefence;
    public Transform attackRange;
    
    public GameObject diedFX;
    public Text texPower;
    public Text texHp;
    public bool isCanBePerfectTrick = false;
    public bool isCanEnterPerfectTrick = false;
    public bool isCanCrateDamage = false;
    public bool isBigAttack = false;
    public CombatData enemyRole;
    //public List<AttackItem>  attackThisArr;
    private float noDamageTimer = 0;
    public bool isDead = false;
    public bool isEnterExecution = false;
    private void Start()
    {
        jiaShiTiao = 5;
        texPower.text = "����ֵ��" + power;
        texHp.text = "����ֵ��" + jiaShiTiao;
    }
    private void Update()
    {
        noDamageTimer -= Time.deltaTime;
    }
    private void LateUpdate()
    {
        //if (jiaShiTiao<=0)
        //{
        //    Instantiate<GameObject>(diedFX, this.transform.position, Quaternion.identity).SetActive(true);
        //    Destroy(this.gameObject);
        //}
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        if (collision.tag == "attackRange")
        {
            var role = collision.transform.parent.GetComponent<CombatData>();
            if (role.isCanCrateDamage)
            {
                
                if (role.isBigAttack)
                {
                    Debug.Log("�����ܻ�");
                    this.changeHP(-9999);
                }
                else
                {
                    if (animator.GetCurrentAnimatorStateInfo(0).IsName("Block"))
                    {
                        if (noDamageTimer > 0)
                        {

                        }
                        else
                        {
                            Debug.Log("��ͨ��");
                            this.changeHP(-1);
                        }
                        (GetComponent<PlayerFSM>().GetState(E_PlayerStates.Block) as PlayerBlockState).curDuration = 0;
                        //����״̬
                    }
                    else
                    {
                        Debug.Log("��ͨ�ܻ�");
                        this.changeHP(-2);
                        //�ܻ�״̬
                    }

                }
                role.isCanCrateDamage = false;
            }
            else
            {
                if (role.isCanBePerfectTrick)
                {
                    isCanEnterPerfectTrick = true;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "attackRange")
        {
            isCanEnterPerfectTrick = false;
        }
    }
    public void startPerfectCheck()
    {
        //Debug.Log(transform.name + "������Ա�����������ʱ��");
        attackRange.gameObject.SetActive(true);
        attackRange.GetComponent<Collider2D>().enabled = true;
        attackRange.GetComponent<Collider2D>().isTrigger = true;
        isCanBePerfectTrick = true;
    }

    public void startAttack()
    {
        //Debug.Log(transform.name + "���빥���ж�ʱ��");
        isCanCrateDamage = true;
        isCanBePerfectTrick = false;
    }
    public void attackEnd()
    {
        //Debug.Log(transform.name+"��������");
        attackRange.GetComponent<Collider2D>().enabled = false;
        attackRange.gameObject.SetActive(false);
        isCanCrateDamage = false;
        attackRange.GetComponent<Collider2D>().isTrigger = false;
    }

    public void Dash()
    {
        if (isCanEnterPerfectTrick)
        {
            //Debug.Log("������");
            noDamageTimer = 0.5f;
            changePower(1);
        }
    }
    public void Block()
    {
        if (isCanEnterPerfectTrick)
        {
            //Debug.Log("��������");
            noDamageTimer = 0.5f;
            changePower(1);
        }
    }

    public void changeHP(int value)
    {
        if (isDead)
            return;
        //Debug.Log(value +"     "+jiaShiTiao);
        jiaShiTiao  +=value;
        jiaShiTiao = Mathf.Max(0, jiaShiTiao);
        texHp.text = "����ֵ��" + jiaShiTiao;
        if (jiaShiTiao <= 0)
        {
            isDead = true;
            GetComponent<PlayerFSM>().animator.Play("Dead");
        }
        else
        {
            GetComponent<PlayerFSM>().animator.Play("Hited");
        }
       
    }
    public void changePower(int value)
    {
        power  +=value;
        power = Mathf.Max(0, jiaShiTiao);
        texPower.text = "����ֵ��" + power;
    }
}
