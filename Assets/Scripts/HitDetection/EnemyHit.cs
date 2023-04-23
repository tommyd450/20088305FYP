using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : Hit
{
    public override void hit() { }
    public GameObject hitEffect;
    public GameObject hitRail;
    public GameObject healthDrop;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Projectile>()!= null)
        {
            if (other.gameObject.GetComponent<Projectile>().GetProjectileType().Equals("MachineGun")) 
            {
                Destroy(other.gameObject);
            }

            GameObject hitReg;
            if (timePassed>3|| other.gameObject.GetComponent<Projectile>().GetProjectileType().Equals("MachineGun")) {
                timePassed = 0;
                health = health - other.gameObject.GetComponent<Projectile>().GetDamageValue();
                if (other.gameObject.GetComponent<Projectile>().GetProjectileType().Equals("MachineGun"))
                {
                    hitReg = Instantiate(hitEffect, this.transform.position, Quaternion.Euler(90f, 0f, 0f));
                    Destroy(hitReg, 2);
                }
                else if (other.gameObject.GetComponent<Projectile>().GetProjectileType().Equals("RailGun")) 
                {
                    hitReg = Instantiate(hitRail, this.transform.position, other.gameObject.transform.rotation);
                    Destroy(hitReg, 2);
                }
                
            }
            
            
            
            if (health < 0)
            {
                GetComponent<SquadManagement>().PassingTheTorch();
                if (Random.value < 0.05) 
                {
                    Instantiate(healthDrop, this.transform.position, Quaternion.identity);
                    
                }
                PlayerPrefs.SetFloat("Currency", PlayerPrefs.GetFloat("Currency") + 5);
                Destroy(this.gameObject);
            }
        }
        
    }

    
}
