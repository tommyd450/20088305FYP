using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Action
{
    public override bool PrePerform()
    {
        


       
            
       return true;
    }
    public override bool PostPerform()
    {
        //target = GameObject.Find("Patrol");
        World.Instance.GetWorld().ModifyState("isHere", 1);
        return true;
    }
}
