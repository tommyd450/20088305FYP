using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailProj : MonoBehaviour
{
    Rigidbody rig;
    //SphereCollider sph;
    [SerializeField] GameObject plr;
    public float chargeMult;
    // Start is called before the first frame update
    void Start()
    {
        plr = GameObject.Find("Player");
        rig = gameObject.GetComponent<Rigidbody>();
        //sph = gameObject.GetComponent<SphereCollider>();
        Vector3 dir = new Vector3(transform.forward.x, 0, transform.forward.z);
        gameObject.transform.position = plr.transform.position + dir;
        rig.AddForce((dir * chargeMult)*200, ForceMode.Impulse);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this,5);
    }
}
