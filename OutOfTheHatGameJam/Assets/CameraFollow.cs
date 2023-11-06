using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The object the camera is following
    public float speed = 0.125f; // The speed of the camera
    private Vector3 offset; // The offset of the camera from the target
    private Vector3 velocity = Vector3.zero; // The velocity of the camera
    public float changeRate = 10f;
    public float maxSize = 10f;
    private float currentSize; 
    public float zoomSpeed = 0.5f;
    
    private float minSpeed = 0f; // The minimum speed of the object
    private float maxSpeed = 20f; // The maximum speed of the object

    
    void Start()
    {
        // Calculate the initial offset
        offset = transform.position - target.position;
        currentSize = Camera.main.orthographicSize;
    }

    void LateUpdate()
    {
        // Calculate the target position
        Vector3 targetPosition = target.position + offset;

        // Smoothly move the camera to the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, speed);

        // Adjust the camera's vertical size based on the object's speed
        float objectSpeed = target.GetComponent<Rigidbody2D>().velocity.magnitude;

        objectSpeed = Mathf.Clamp(objectSpeed, minSpeed, maxSpeed);
        //Debug.Log("object speed is "+ objectSpeed);
        
        float newSize;
        if (objectSpeed == 0)
        {
            // If the object's speed is zero, set the new size to the current size
            newSize = currentSize;
        }
        else
        {
            newSize = Mathf.Lerp(5, 10, objectSpeed / 10);
        }

        // If the new size exceeds the maximum size, set it to the maximum size
        if (newSize > maxSize)
        {
            newSize = maxSize;
            
        }

        if (newSize < maxSize)
        {
           currentSize = Mathf.MoveTowards(currentSize, newSize, zoomSpeed * Time.deltaTime);
            
        }
        else
        {
            currentSize = newSize;
        }

        if (objectSpeed<5f)
        {
            //zone to fix the camera snapping problem
           // currentSize = Mathf.MoveTowards(currentSize, newSize, zoomSpeed * Time.deltaTime);
          //  Debug.Log(objectSpeed);
        }

        Camera.main.orthographicSize = newSize;
    }
}