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
            Debug.Log(collision.name + "因为" + this.name + "而受击");
            collision.GetComponent<IDamageable>().OnHited();
        }
    }
}
