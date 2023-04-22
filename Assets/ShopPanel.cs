using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class ShopPanel : MonoBehaviour
{
    List<System.Type> ty = new List<System.Type>() { typeof(WeaponMG),typeof(WeaponHelix),typeof(WeaponRail)};
   
    WeaponMG mg;
    WeaponRail rg;
    WeaponHelix hx;
    System.Type forSale;
    GameObject saleText;
    GameObject toggle;
    public GameObject wholeShop;
    // Start is called before the first frame update
    void Start()
    {
       


        saleText = GameObject.Find("WeaponListing");
        toggle = GameObject.Find("SlotToggle");
        SetWeaponForSale();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetWeaponForSale() 
    {
        forSale = ty.ElementAt(Random.Range(0,3));
       
        saleText.GetComponent<TextMeshProUGUI>().text = forSale.ToString()+ " for 300";
    }



    public void purchaseWeapon() 
    {

        GameObject wepSlots = GameObject.Find("WeaponManager");


        if (toggle.GetComponent<Toggle>().isOn)
        {



            if (wepSlots.GetComponent<WeaponSlots>().activeWeapon == wepSlots.GetComponent<WeaponSlots>().slot1)
            {
                wepSlots.GetComponent<WeaponSlots>().end();
                wepSlots.GetComponent<WeaponSlots>().slot2 = wepSlots.GetComponent(forSale) as Weapon;
            }


            wepSlots.GetComponent<WeaponSlots>().activeWeapon = wepSlots.GetComponent(forSale) as Weapon;
        }
        else 
        {
            if (wepSlots.GetComponent<WeaponSlots>().activeWeapon == wepSlots.GetComponent<WeaponSlots>().slot2)
            {
                wepSlots.GetComponent<WeaponSlots>().end();
                wepSlots.GetComponent<WeaponSlots>().slot1 = wepSlots.GetComponent(forSale) as Weapon;
            }
            wepSlots.GetComponent<WeaponSlots>().activeWeapon = wepSlots.GetComponent(forSale) as Weapon;
        }
       
        
    }

    public void purchaseHealth()
    {

    }

    public void closePanel() 
    {
        if (Time.timeScale == 0) 
        {
            Time.timeScale = 1;
            this.gameObject.SetActive(false);
        }
    }
}
