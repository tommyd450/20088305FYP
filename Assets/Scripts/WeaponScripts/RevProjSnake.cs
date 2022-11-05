using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevProjSnake : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject proj;
    Rigidbody rig;
    SphereCollider sph;
    [SerializeField] GameObject plr;
    [SerializeField] float freq;
    [SerializeField] float width;
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

        pos += transform.forward * Time.deltaTime * 75.0f;
        gameObject.transform.position = (pos + axis * Mathf.Sin(-(Time.time - startTime) * freq) * width);
    }
}
