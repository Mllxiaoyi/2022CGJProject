using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCauser : MonoBehaviour
{
    public string targetTag;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            Debug.Log(collision.name + "��Ϊ" + this.name + "���ܻ�");
            collision.GetComponent<IDamageable>().OnHited();
        }
    }
}
