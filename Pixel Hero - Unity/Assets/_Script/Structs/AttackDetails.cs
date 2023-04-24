using UnityEngine;

[System.Serializable]
public struct WeaponAttackDetails
{
    public string attackName;
    public float movementSpeed;
    public float damageAmount;
    //public float stunDamageAmount;

    public float knockbackStrength;
    public Vector2 knockbackAngle;
}
