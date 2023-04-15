using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Progression : MonoBehaviour
{

    BoxCollider bx;
    float health;
    
    // Start is called before the first frame update
    void Start()
    {
        bx = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {

            health = other.gameObject.GetComponent<Hit>().health;
            PlayerPrefs.SetFloat("Health", health);
            SceneManager.LoadScene(1);
        }
    }
}
