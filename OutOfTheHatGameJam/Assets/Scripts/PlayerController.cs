using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  
    public float moveSpeed = 5f;
   
    private Rigidbody2D rb;
   
    private void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
    }
   
    private void Update() { 
        float moveInput = Input.GetAxis("Horizontal"); 
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
   
}
