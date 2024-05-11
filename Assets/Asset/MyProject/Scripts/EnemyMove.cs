using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;

    public void MoveTo(Vector3 position)
    {
        agent.isStopped = false;
        agent.SetDestination(position);
        animator.SetFloat("Speed", agent.speed);
    }

    public void Stop()
    {
        agent.isStopped = true;
        animator.SetFloat("Speed", 0);
    }
}
