using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHit : Hit
{
    public GameObject healthBar;
    void Start()
    {
        healthBar = GameObject.Find("HealthBar");
        if (PlayerPrefs.HasKey("Health")) 
        {
            health = PlayerPrefs.GetFloat("Health");
            healthBar.GetComponent<Image>().fillAmount = health/100;
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("EnemyProj") && timePassed > 0.5)
        {
            Destroy(other.gameObject);
            timePassed = 0;
            health = health - 10;
            healthBar.GetComponent<Image>().fillAmount = health / 100;
            if (health <= 0)
            {

                Destroy(this.gameObject);
            }
        }
        else if (other.gameObject.tag.Equals("EnemyProj")) 
        {
            Destroy(other.gameObject);
        }
    }

    public override void hit() { }
}
