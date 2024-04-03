using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator; // Reference to the Animator component
    private NavMeshAgent agent; // Reference to the NavMeshAgent component

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the NavMeshAgent has a velocity, indicating that the enemy is moving
        if (agent.velocity.magnitude > 0)
        {
            // If the enemy is moving, play the "Moving" animation
            animator.SetBool("DemoAnimatorRun2", true);
        }
        else
        {
            // If the enemy is not moving, stop the "Moving" animation
            animator.SetBool("DemoAnimatorRun2", false);
        }
    }
}
