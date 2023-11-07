using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChaseScript : MonoBehaviour
{
    public float targetXPosition; // The second X position
    private Vector2 currentPosition; // The current position
    public float timeDuration; // The time duration

    void Start()
    {
        // Store the current position
        currentPosition = transform.position;
    }

    void Update()
    {
        // Calculate the target position
        Vector2 targetPosition = new Vector2(targetXPosition, currentPosition.y);

        // Move the object towards the target position
        float step = Vector2.Distance(currentPosition, targetPosition) / timeDuration * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);

        // Update the current position
        currentPosition = transform.position;
    }
}
