using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private Attacker attacker;
    [SerializeField] private Motion mover;
    [SerializeField] private Health health;
    [SerializeField] private InputManager input;
    private float timeToRestart = 2;

    public bool IsDead => health.IsDead;

    private void Update()
    {
        if (timeToRestart <= 0) SceneManager.LoadScene(2);

        if (health.IsDead)
        {
            timeToRestart -= Time.deltaTime;
            return;
        }

        if (input.Attacking) attacker.Attack();

        if (!attacker.AttackProcess) mover.Move(input.Motion);
    }
}
