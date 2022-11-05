using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjSnake : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject proj;
    Rigidbody rig;
    SphereCollider sph;
    [SerializeField] GameObject plr;
    float startTime;
    Vector3 pos;
    Vector3 axis;
    void Start()
    {
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
        
        pos += transform.forward * Time.deltaTime * 50.0f;
        gameObject.transform.position = pos + axis * Mathf.Sin(1) * 100;
    }
}
