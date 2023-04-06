using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailProj : Projectile
{
    Rigidbody rig;
    //SphereCollider sph;
    [SerializeField] GameObject plr;
    public float chargeMult;
    // Start is called before the first frame update


    private string projectileType = "";
    private float damageValue = 0;

    void Start()
    {

        
        plr = GameObject.Find("Player");
        rig = gameObject.GetComponent<Rigidbody>();
        //sph = gameObject.GetComponent<SphereCollider>();
        Vector3 dir = new Vector3(transform.forward.x, 0, transform.forward.z);
        gameObject.transform.position = plr.transform.position + dir;
        rig.AddForce((dir * chargeMult)*200, ForceMode.Impulse);
        SetProjectileType("RailGun");
        SetDamage(45*chargeMult); //Up to 90 damage
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

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this,5);
    }
}
