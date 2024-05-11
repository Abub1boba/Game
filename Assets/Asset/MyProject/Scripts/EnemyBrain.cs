using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBrain : MonoBehaviour
{
    [SerializeField] private Attacker attacker;
    [SerializeField] private EnemyMove mover;
    [SerializeField] private Health health;
    private float timeToDestroy = 5;

    private Player player;

    private void Start() => player = FindAnyObjectByType<Player>();

    private void Update()
    {

        if (health.IsDead)
        {
            Destroy(gameObject, 5f);
            return;
        }
        if (player.IsDead) return;

        if (attacker.InRange(player.transform.position))
        {
            mover.Stop();
            attacker.Attack();
        }

        else if (!attacker.AttackProcess) mover.MoveTo(player.transform.position);
    }
}
