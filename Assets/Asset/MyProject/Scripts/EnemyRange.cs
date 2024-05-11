using UnityEngine;
using UnityEngine.AI;

public class EnemyRange : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    [SerializeField] private float range;
    private Transform player;

    void Start()
    {
        player = FindAnyObjectByType<Motion>().transform;
        agent.SetDestination(FindNewPont());
    }

    void Update()
    {
        if (agent.remainingDistance <= 0.3f)
        {
            agent.SetDestination(FindNewPont());
        }
        animator.SetFloat("Speed", agent.speed);
    }

    private Vector3 FindNewPont()
    {
        Vector2 pointV2 = Random.insideUnitCircle;
        Vector3 position = new Vector3(pointV2.x, 0, pointV2.y);
        if (Mathf.Abs(position.x) < range / 3)
        {
            position.x *= 1.5f;
        }
        if (Mathf.Abs(position.z) < range / 3)
        {
            position.z *= 1.5f;
        }
        position *= range;
        position += player.position;
        return position;
    }
}
