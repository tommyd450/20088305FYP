using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjSnake : Projectile
{
    // Start is called before the first frame update
    [SerializeField] GameObject proj;
    Rigidbody rig;
    SphereCollider sph;
    [SerializeField] GameObject plr;
    [SerializeField] float freq;
    [SerializeField] float width;

    private string projectileType = "";
    private float damageValue = 0;
    float startTime;
    Vector3 pos;
    Vector3 axis;
    void Start()
    {
        SetProjectileType("MachineGun");
        SetDamage(20);
        plr = GameObject.Find("Player");
        rig = gameObject.GetComponent<Rigidbody>();
        sph = gameObject.GetComponent<SphereCollider>();
        Vector3 dir = new Vector3(transform.forward.x, 0, transform.forward.z);
        gameObject.transform.position = plr.transform.position + dir;
        //rig.AddForce(dir * 10, ForceMode.Impulse);
        startTime = Time.time;
        pos = transform.position;
        axis = transform.right;
        axis.y = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.position = gameObject.transform.position + transform.forward;
        
        pos += transform.forward * Time.deltaTime * 75.0f;
        gameObject.transform.position = (pos + axis * Mathf.Sin((Time.time-startTime)*freq) * width);
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
