using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : Action
{
    public override bool PrePerform()
    {
        target = GameObject.Find("Player");


        if (target != null && World.Instance.GetWorld().HasState("isHere"))
        {
            return true;
        }
        return false;
    }
    public override bool PostPerform()
    {
        //World.Instance.GetWorld().ModifyState("isHere", 1);
        return true;
    }

}
