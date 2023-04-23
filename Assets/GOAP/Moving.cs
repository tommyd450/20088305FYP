using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.AI ;
using UnityEngine;

public class Moving : Action
{/*
 * These Scripts were created following a course I did on Goal Oriented Action Planning,
 * The Course was created by Penny de Byl by following a course created by her at this site https://learn.holistic3d.com/course/goap/
 * These scripts are not used within the project as the project shifted away from Goal Oriented Action Planning
 *
 */

    public override bool PrePerform()
    {
        if (target == null)
        {
            target = GameObject.Find("Player");
        }


        if (target != null)
        {
            
            return true;
        }
     
        
        return false;
    }
    public override bool PostPerform()
    {
        print("Post Perform on Move");
        print("Distance " + Vector3.Distance(this.transform.position, target.transform.position));
        if (Vector3.Distance(this.transform.position, target.transform.position) < 15)
        {
            if (!World.Instance.GetWorld().HasState("inRange"))
            {
                World.Instance.GetWorld().AddState("inRange", 1);
            }
            print("InRange");
        }
        else if (World.Instance.GetWorld().HasState("inRange"))
        {
            print("Out of Range");
            World.Instance.GetWorld().RemoveState("inRange");
            return false;
        }
        return true;
    }

}
