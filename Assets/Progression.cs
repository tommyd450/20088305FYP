using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Progression : MonoBehaviour
{

    BoxCollider bx;
    float health;
    GameObject weaponManager;
    
    // Start is called before the first frame update
    void Start()
    {
        weaponManager = GameObject.Find("WeaponManager");
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
            DontDestroyOnLoad(weaponManager);
            SceneManager.LoadScene(1);
        }
    }
}
