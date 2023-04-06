using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjBullet : Projectile
{
    [SerializeField] GameObject proj;
    Rigidbody rig;
    SphereCollider sph;
    [SerializeField]GameObject plr;
    // Start is called before the first frame update
    private string projectileType = "";
    private float damageValue = 0;

    void Start()
    {
        plr = GameObject.Find("Player");
        rig = gameObject.GetComponent<Rigidbody>();
        sph = gameObject.GetComponent<SphereCollider>();
        Vector3 dir = new Vector3(transform.forward.x*2.5f, 0, transform.forward.z*2.5f);
        gameObject.transform.position = plr.transform.position+dir;
        rig.AddForce(dir*50,ForceMode.Impulse);
        SetProjectileType("MachineGun");
        SetDamage(20); //Up to 90 damage
    }
    public override float GetDamageValue()
    {
        return damageValue;
    }

    public override void SetDamage(float dmg)
    {
        damageValue = dmg;
    }

    public override void SetProjectileType(string type)
    {
        projectileType = type;
    }

    public override string GetProjectileType()
    {
        return projectileType;
    }



}
