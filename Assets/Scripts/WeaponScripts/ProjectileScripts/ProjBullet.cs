using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjBullet : MonoBehaviour
{
    [SerializeField] GameObject proj;
    Rigidbody rig;
    SphereCollider sph;
    [SerializeField]GameObject plr;
    // Start is called before the first frame update
    void Start()
    {
        plr = GameObject.Find("Player");
        rig = gameObject.GetComponent<Rigidbody>();
        sph = gameObject.GetComponent<SphereCollider>();
        Vector3 dir = new Vector3(transform.forward.x*2.5f, 0, transform.forward.z*2.5f);
        gameObject.transform.position = plr.transform.position+dir;
        rig.AddForce(dir*100,ForceMode.Impulse);
    }

    
    

}
