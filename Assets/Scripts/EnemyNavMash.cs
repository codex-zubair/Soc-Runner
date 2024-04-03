using UnityEngine;
using UnityEngine.AI;

public class EnemyFollower : MonoBehaviour
{
    public Transform target; // Reference to the car object
    public float attackRange = 5f; // Range within which the enemy attacks the player
    private NavMeshAgent agent; // Reference to the NavMeshAgent component
    public float rotationSpeed = 10f; // Rotation speed of the enemy

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false; // Disable automatic rotation by NavMeshAgent
    }

    void Update()
    {
        // Check if the target is assigned
        if (target == null)
            return;

        // Calculate the distance to the target
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Check if the player is within attack range
        if (distanceToTarget <= attackRange)
        {
            // Set the destination of the NavMeshAgent to the target's position
            agent.SetDestination(target.position);

            // Calculate the direction to the target
            Vector3 targetDirection = (target.position - transform.position).normalized;

            // Calculate the rotation towards the target
            Quaternion targetRotation = Quaternion.LookRotation(-targetDirection); // Invert the direction

            // Smoothly rotate the enemy towards the target
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // Stop moving if the player is out of attack range
            agent.ResetPath();
        }
    }
}
