using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : Hit
{
    public override void hit() { } 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("PlayerProj") && timePassed > 0.5)
        {

            timePassed = 0;
            health = health - 10;
            print("health: " + health);

            if (health < 0)
            {
                GetComponent<SquadManagement>().PassingTheTorch();

                Destroy(this.gameObject);
            }
        } else if (other.gameObject.tag.Equals("PlayerProj")) 
        {
            Destroy(other.gameObject);
        }
    }

    
}
