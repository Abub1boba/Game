using UnityEngine;

public class Attacker : MonoBehaviour
{
    private bool CanAttack => attackTime <= 0;
    public bool AttackProcess => attackCoolDown - attackTime <= 0.9f;
    [SerializeField] private LayerMask AttackMask;
    [SerializeField] private Animator animator;
    [SerializeField] private float damage;
    [SerializeField] private float attackCoolDown;
    [SerializeField] private float range;
    [SerializeField] private Vector3 WeaponRange;
    private Collider[] hits = new Collider[5];
    private float attackTime = 0;

    void Update() => attackTime -= Time.deltaTime;

    public void Attack()
    {
        if (CanAttack)
        {
            AnimateAttack();
            DamageEnemy();
            ResetTime();
        }
    }

    private void ResetTime() => attackTime = attackCoolDown;

    private void AnimateAttack()
    {
        var RandomIndex = Random.Range(1, 2);
        animator.SetInteger("AttackingIndex", RandomIndex);
        animator.SetTrigger("Attacking");
    }

    private void DamageEnemy()
    {
        int count = Physics.OverlapSphereNonAlloc(transform.position + WeaponRange, range, hits, AttackMask);
        for (int i = 0; i < count; i++)
        {
            if (hits[i].TryGetComponent<Health>(out var health))
            {
                health.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position + transform.forward + WeaponRange, range);

        Gizmos.color = Color.white;
        Gizmos.DrawSphere(transform.position + transform.forward + WeaponRange, 0.2f);
    }

    public bool InRange(Vector3 position) => Vector3.Distance(transform.position, position) <= range;
}
