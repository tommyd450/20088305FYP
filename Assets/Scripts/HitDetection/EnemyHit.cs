using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : Hit
{
    public override void hit() { } 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("PlayerProj") && timePassed > 2) 
        {
            timePassed = 0;
            health = health - 10;
            print("health: " + health);
        }
    }
}
