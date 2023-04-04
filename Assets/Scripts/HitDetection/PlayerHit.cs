using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : Hit
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("EnemyProj") && timePassed > 0.5)
        {
            timePassed = 0;
            health = health - 10;
            print("health: " + health);

            if (health < 0)
            {
                GetComponent<SquadManagement>().PassingTheTorch();
                Destroy(this.gameObject, 1);
            }
        }
    }

    public override void hit() { }
}
