using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   public int health = 100; // Health of the object
   public GameObject objectToDestroy; 
   public void TakeDamage(int damage)
   {
       health -= damage;
       if (health <= 0)
       {
           print("Health is " + health);
           // Destroy the object or do something else when health is 0
           Destroy(objectToDestroy);
       }
   }
}
