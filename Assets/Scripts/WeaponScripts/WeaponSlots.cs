using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlots : MonoBehaviour
{
    Weapon slot1;
    Weapon slot2;
    Weapon activeWeapon;
    private PlayerControls playerControls;
    WeaponMG mg;
    WeaponRail rl;
    BoxCollider bx;

    
    void Start()
    {
        mg = GetComponent<WeaponMG>();
        rl = GetComponent<WeaponRail>();
        slot1 = mg;
        slot2 = rl;
        activeWeapon = slot1;
        bx = GetComponent<BoxCollider>();
    }

    private void Awake()
    {
        print("Everytime");
        playerControls = new PlayerControls();
        playerControls.Controls.SwapWep.started += _ => swap();
        playerControls.Controls.SwapWep.canceled += _ => stopped();
        playerControls.Controls.Shoot.started += _ => start();  
        playerControls.Controls.Shoot.canceled += _ => end();
        playerControls.Controls.PickUp.started += _ => PickUpWeapon();
        
    }

    void Update()
    {
        
    }

    void start() 
    {
        activeWeapon.attackInitiated();
        print(activeWeapon.GetType());
    }

    void end() 
    {
        activeWeapon.attackReleased();
    }

    public void swap() 
    {
        activeWeapon.stopCouroutine();
        if (activeWeapon == slot1)
        {
            activeWeapon = slot2;
        }
        else if (activeWeapon == slot2) 
        {
            activeWeapon = slot1;
        }

    }

    public void stopped()
    {
        
    }


    public void PickUpWeapon() 
    {
        if (bx.bounds.Contains(GameObject.Find("HelixPickUp").transform.position))
        {
            Weapon prev = activeWeapon;
            activeWeapon = GetComponent<WeaponHelix>();
            if (slot1 == prev)
            {
                slot1 = activeWeapon;
            }
            else if (slot2 == prev) 
            {
                slot2 = activeWeapon;
            }
        }
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
