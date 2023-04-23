using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : Action
{

    /*
    * These Scripts were created following a course I did on Goal Oriented Action Planning,
    * The Course was created by Penny de Byl by following a course created by her at this site https://learn.holistic3d.com/course/goap/
    * These scripts are not used within the project as the project shifted away from Goal Oriented Action Planning
    * 
    */
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
