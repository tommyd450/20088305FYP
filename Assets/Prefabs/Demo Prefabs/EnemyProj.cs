using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProj : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject proj;
    Rigidbody rig;
    SphereCollider sph;
    // Start is called before the first frame update
    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody>();
        sph = gameObject.GetComponent<SphereCollider>();
        Debug.Log(transform.position);
        Vector3 dir = new Vector3(transform.forward.x , 0, transform.forward.z );
        gameObject.transform.position = dir;
        rig.AddForce(dir * 50, ForceMode.Impulse);
    }
}
