using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
using UnityEngine.UI;

public class CombatData : MonoBehaviour
{
    public int jiaShiTiao;
    public int power;
=======
using UnityEngine.Events;
using TMPro;
public class CombatData : MonoBehaviour,IDamageable
{
    public int jiaShiTiao;
    public int energy;
    private Animator _animator;
>>>>>>> Stashed changes

    public Animator animator;

<<<<<<< Updated upstream
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
        texPower.text = "能量值：" + power;
        texHp.text = "架势值：" + jiaShiTiao;
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
                    Debug.Log("蓄能受击");
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
                            Debug.Log("普通格挡");
                            this.changeHP(-1);
                        }
                        (GetComponent<PlayerFSM>().GetState(E_PlayerStates.Block) as PlayerBlockState).curDuration = 0;
                        //击退状态
                    }
                    else
                    {
                        Debug.Log("普通受击");
                        this.changeHP(-2);
                        GetComponent<Animator>().Play("Hited");
                        //受击状态
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
=======
    public TMP_Text hpText;

    public GameObject diedFX;

    public string campTag = "Enemy";

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
>>>>>>> Stashed changes
    }
    public void startPerfectCheck()
    {
<<<<<<< Updated upstream
        //Debug.Log(transform.name + "进入可以被完美格挡闪避时间");
        attackRange.gameObject.SetActive(true);
        attackRange.GetComponent<Collider2D>().enabled = true;
        attackRange.GetComponent<Collider2D>().isTrigger = true;
        isCanBePerfectTrick = true;
    }

    public void startAttack()
    {
        //Debug.Log(transform.name + "进入攻击判定时间");
        isCanCrateDamage = true;
        isCanBePerfectTrick = false;
    }
    public void attackEnd()
    {
        //Debug.Log(transform.name+"攻击结束");
        attackRange.GetComponent<Collider2D>().enabled = false;
        attackRange.gameObject.SetActive(false);
        isCanCrateDamage = false;
        attackRange.GetComponent<Collider2D>().isTrigger = false;
    }

    public void Dash()
    {
        if (isCanEnterPerfectTrick)
=======
        //Debug.Log(name + "OnTriggerEnter2D");
        if (collision.tag != "Player" && collision.tag != "Enemy") { return; }
        if (tag == collision.tag) { return; }     
        
        
    }

    void IDamageable.OnHited()
    {
        OnHited?.Invoke();
        
        //if (animator.GetCurrentAnimatorStateInfo(0).IsName("Block")) { return; }
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("PerfectBlock"))
>>>>>>> Stashed changes
        {
            //Debug.Log("完美格挡");
            noDamageTimer = 0.5f;
            changePower(1);
        }
<<<<<<< Updated upstream
    }
    public void Block()
    {
        if (isCanEnterPerfectTrick)
        {
            //Debug.Log("完美闪避");
            noDamageTimer = 0.5f;
            changePower(1);
=======
        else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Block"))
        {
            Debug.Log("普通格挡");
            jiaShiTiao--;
            OnDamaged?.Invoke();
>>>>>>> Stashed changes
        }
    }

    public void changeHP(int value)
    {
        if (isDead)
            return;
        //Debug.Log(value + "     " + jiaShiTiao);
        jiaShiTiao  +=value;
        jiaShiTiao = Mathf.Max(0, jiaShiTiao);
        texHp.text = "架势值：" + jiaShiTiao;
        if (jiaShiTiao <= 0)
        {
<<<<<<< Updated upstream
            isDead = true;
            GetComponent<Animator>().Play("Dead");
=======
            jiaShiTiao -= 2;
            OnDamaged?.Invoke();
        }

        if (jiaShiTiao <= 0)
        {
            OnDied?.Invoke();
            this.tag = "Untagged";
            return;
>>>>>>> Stashed changes
        }
    }
    public void changePower(int value)
    {
        power  +=value;
        power = Mathf.Max(0, jiaShiTiao);
        texPower.text = "能量值：" + power;
    }

   
}
