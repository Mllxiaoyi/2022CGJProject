using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCauser : MonoBehaviour
{
    public string targetCamps = "Enemy";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetCamps))
        {
            collision.GetComponent<IDamageable>().OnHited();
            Debug.Log(collision.name + "��Ϊ" +this.transform.parent.name+"��"+ this.name + "�ܻ�");
        }
    }
}
