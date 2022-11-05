using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObject : MonoBehaviour
{

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject Weapon;
    GameObject player;
    
    Rigidbody playerBod;
   

    public WeaponObject wep;
    private PlayerControls playerControls;
    void Start()
    {
        player = GameObject.Find("Player");
        playerBod = player.GetComponent<Rigidbody>();
        //projBody = projectile.GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Controls.Shoot.started += _ => wep.Awake();
        //playerControls.Controls.Shoot.canceled += _ => cease();
    }

    void Update()
    {
        player = GameObject.Find("Player");
    }



    public void shoot() 
    {
    
    }

    

    private void OnEnable()
    {
        playerControls.Enable();
        
    }

    private void OnDisable()
    {
        //playerControls.Controls.Shoot.performed -= ctx => shoot();
        playerControls.Disable();
    }
}
