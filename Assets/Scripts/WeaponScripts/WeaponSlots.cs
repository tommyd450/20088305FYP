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

    
    void Start()
    {
        mg = GetComponent<WeaponMG>();
        rl = GetComponent<WeaponRail>();
        slot1 = mg;
        slot2 = rl;
        activeWeapon = slot1;
    }

    private void Awake()
    {
        print("Everytime");
        playerControls = new PlayerControls();
        playerControls.Controls.SwapWep.started += _ => swap();
        playerControls.Controls.SwapWep.canceled += _ => stopped();
        playerControls.Controls.Shoot.started += _ => start();  
        playerControls.Controls.Shoot.canceled += _ => end();
        
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
        print("swapPressed");

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
