using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmGoals : Agent
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        //SubGoal s1 = new SubGoal("moveF", 3,false);
       // goals.Add(s1, 3);

        SubGoal s2 = new SubGoal("attack", 1,false);
        goals.Add(s2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
