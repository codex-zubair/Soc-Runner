using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target; // Reference to the car object
    public float moveSpeed = 5f; // Speed of the enemy movement
    public float detectionRange = 10f; // Range at which the enemy detects the car

    private bool isChasing = false;

    void Update()
    {
        // Check if the car is within the detection range
        if (Vector3.Distance(transform.position, target.position) <= detectionRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        // If chasing, move towards the car
        if (isChasing)
        {
            Vector3 moveDirection = (target.position - transform.position).normalized;
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
    }
}