using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class healthPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            if (other.GetComponent<Hit>().health + 20 <= 100)
            {
                other.GetComponent<Hit>().health += 20;
                other.GetComponent<PlayerHit>().healthBar.GetComponent<Image>().fillAmount = other.GetComponent<Hit>().health / 100;
            }
            else 
            {
                other.GetComponent<Hit>().health += 10;
                other.GetComponent<PlayerHit>().healthBar.GetComponent<Image>().fillAmount = other.GetComponent<Hit>().health / 100;
            }
            Destroy(this.gameObject);
        }
    }
}
