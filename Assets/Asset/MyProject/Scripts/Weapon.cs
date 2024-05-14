using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Config/Weapon", order = 0)]
public class Weapon : ScriptableObject
{
    [SerializeField] public float AttackTime;
    [SerializeField] public float damage;
    [SerializeField] public float attackCoolDown;
    [SerializeField] public float range;
    [SerializeField] public GameObject prefab;
}
