using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WeaponSlots : MonoBehaviour
{
    public Weapon slot1;
    public Weapon slot2;
    public Weapon activeWeapon;
    public GameObject weaponUi;
    private PlayerControls playerControls;
    WeaponMG mg;
    WeaponRail rl;
    WeaponHelix hx;
    BoxCollider bx;

    
    void Start()
    {

        
        mg = GetComponent<WeaponMG>();
        rl = GetComponent<WeaponRail>();
        hx = GetComponent<WeaponHelix>();
        slot1 = mg;
        slot2 = rl;
        activeWeapon = slot1;
        bx = GetComponent<BoxCollider>();
        weaponUi = GameObject.Find("UIManagement").transform.Find("UI").gameObject.transform.Find("EquippedWeapon").gameObject;
        if (weaponUi != null) 
        {
            weaponUi.GetComponent<TextMeshProUGUI>().text = activeWeapon.returnName();
        }
        
    }

   
    
    private void Awake()
    {
        
        
            
            
        
    }

    void Update()
    {
        
    }

    public void setUi() 
    {
        weaponUi = GameObject.Find("UIManagement").transform.Find("UI").gameObject.transform.Find("EquippedWeapon").gameObject;
        if (weaponUi != null)
        {
            weaponUi.GetComponent<TextMeshProUGUI>().text = activeWeapon.returnName();
        }
    }

    public void start() 
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

    


}
