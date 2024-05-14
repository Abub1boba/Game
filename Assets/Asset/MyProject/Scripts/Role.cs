using UnityEngine;

[CreateAssetMenu(fileName = "Role", menuName = "Config/Role", order = 1)]
public class Role : ScriptableObject
{
    public Weapon weapon;
    public float startHealth;
}
