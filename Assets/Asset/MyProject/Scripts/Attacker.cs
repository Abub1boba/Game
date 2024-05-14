using UnityEngine;

public class Attacker : MonoBehaviour
{
    private bool CanAttack => attackTime <= 0;
    public bool AttackProcess => StaticData.playerRole.weapon.attackCoolDown - attackTime <= StaticData.playerRole.weapon.MoveTime;
    [SerializeField] private LayerMask AttackMask;
    [SerializeField] private Animator animator;
    [SerializeField] private Vector3 WeaponRange;
    [SerializeField] private Transform hand;
    private Collider[] hits = new Collider[5];
    private float attackTime = 0;

    void Update() => attackTime -= Time.deltaTime;

    public void SetWeapon(Weapon Weapon)
    {
        Instantiate(Weapon.prefab, hand);

        if (Weapon.controller != null) animator.runtimeAnimatorController = Weapon.controller;
    }

    public void Attack()
    {
        if (CanAttack)
        {
            AnimateAttack();
            DamageEnemy();
            ResetTime();
        }
    }

    private void ResetTime() => attackTime = StaticData.playerRole.weapon.attackCoolDown;

    private void AnimateAttack() => animator.SetTrigger("Attacking");

    private void DamageEnemy()
    {
        int count = Physics.OverlapSphereNonAlloc(transform.position + WeaponRange, StaticData.playerRole.weapon.range, hits, AttackMask);
        for (int i = 0; i < count; i++)
        {
            if (hits[i].TryGetComponent<Health>(out var health))
            {
                health.TakeDamage(StaticData.playerRole.weapon.damage);
            }
        }
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawWireSphere(transform.position + transform.forward + WeaponRange, weapon.range);

    //    Gizmos.color = Color.white;
    //    Gizmos.DrawSphere(transform.position + transform.forward + WeaponRange, 0.2f);
    //}

    public bool InRange(Vector3 position) => Vector3.Distance(transform.position, position) <= StaticData.playerRole.weapon.range;
}
