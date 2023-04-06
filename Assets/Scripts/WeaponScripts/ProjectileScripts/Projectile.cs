using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    
    public abstract void SetDamage(float dmg);
    public abstract void SetProjectileType(string type);
    public abstract float GetDamageValue();
    public abstract string GetProjectileType();

}
