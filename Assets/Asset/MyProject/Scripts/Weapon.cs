using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Config/Weapon", order = 0)]
public class Weapon : ScriptableObject
{
    [field: SerializeField] public float MoveTime { get; private set; }
    [field: SerializeField] public float damage { get; private set; }
    [field: SerializeField] public float attackCoolDown { get; private set; }
    [field: SerializeField] public float range { get; private set; }
    [field: SerializeField] public GameObject prefab { get; private set; }
    [field: SerializeField] public AnimatorOverrideController controller { get; private set; }
}
