using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : Action
{
    public GameObject proj;
    // Start is called before the first frame update
    public override bool PrePerform()
    {
        if (target == null)
        {
            target = GameObject.Find("Player");
        }

       


        if (target != null)
        {
            print("This");
            return true;
        }

        
        return false;
    }
    public override bool PostPerform()
    {
        print("DONG");


        GameObject g = Instantiate(proj, this.transform.position, this.transform.rotation);
        Rigidbody b;
        b = g.GetComponent<Rigidbody>();
        Vector3 dir = new Vector3(transform.forward.x, 0, transform.forward.z);
        b.AddForce(dir * 50, ForceMode.Impulse);
        Destroy(g, 1);

        return true;
    }
}
