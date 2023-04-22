using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WeaponSlots : MonoBehaviour
{
    public Weapon slot1;
    public Weapon slot2;
    public Weapon activeWeapon;
    public GameObject weaponUi;
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
        weaponUi = GameObject.Find("UIManagement").transform.Find("UI").gameObject.transform.Find("EquippedWeapon").gameObject;
        weaponUi.GetComponent<TextMeshProUGUI>().text = activeWeapon.returnName();
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

    public void end() 
    {
        activeWeapon.attackReleased();
    }

    public void swap() 
    {
        activeWeapon.stopCouroutine();
        if (activeWeapon == slot1)
        {
            
            activeWeapon = slot2;
            weaponUi.GetComponent<TextMeshProUGUI>().text = "Slot2 = "+activeWeapon.returnName();
        }
        else if (activeWeapon == slot2) 
        {
            activeWeapon = slot1;
            weaponUi.GetComponent<TextMeshProUGUI>().text = "Slot 1 = "+activeWeapon.returnName();
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
