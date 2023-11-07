using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShifter : MonoBehaviour
{
    public GameObject object1; // The first game object
    public GameObject object2; // The second game object
    public Rigidbody2D rb; // The Rigidbody2D to be modified
    private bool changed = false; // A state change
    public float zRotation = 90f;
    void Update()
    {
        // Check if the L-shift key is pressed
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // Toggle the game objects
            object1.SetActive(!object1.activeSelf);
            object2.SetActive(!object2.activeSelf);
            
            changed = !changed;
            // Toggle the freeze rotation of the Rigidbody2D
            if (changed)
            {
                rb.constraints &= ~RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
               
                rb.constraints |= RigidbodyConstraints2D.FreezeRotation; 
                //rb.transform.Rotate(0, 0, zRotation);
                rb.transform.eulerAngles = new Vector3(rb.transform.eulerAngles.x, rb.transform.eulerAngles.y, zRotation);
            }

            // Trigger the state change
            
        }
    }
}

