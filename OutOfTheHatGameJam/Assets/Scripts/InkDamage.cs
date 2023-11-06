using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkDamage : MonoBehaviour
{
    public int damage = 10; // Damage inflicted by the object

    void OnTriggerEnter2D(Collider2D other)
    {
        print("trigger entered");
        Health health = other.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}
