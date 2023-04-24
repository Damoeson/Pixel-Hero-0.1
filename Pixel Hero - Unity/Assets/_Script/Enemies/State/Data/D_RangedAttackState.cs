using UnityEngine;

[CreateAssetMenu(fileName = "newRangeAttackStateData", menuName = "Data/State Data/Ranged Attack Data")]

public class D_RangedAttackState : ScriptableObject
{
    public GameObject projectile;
    public float projectileDamage = 10f;
    public float projectileSpeed = 12f;
    public float projectileTravelDistance;
}
