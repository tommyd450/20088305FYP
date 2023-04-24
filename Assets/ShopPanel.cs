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
    public GameObject saleText;
    public GameObject healthText;
    GameObject toggle;
    public GameObject wholeShop;
    // Start is called before the first frame update
    void Start()
    {
       


        saleText = GameObject.Find("WeaponListing");
        toggle = GameObject.Find("SlotToggle");
        SetWeaponForSale();
        SetHealthText();
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

    void SetHealthText() 
    {
        healthText.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("HealthCost") + " to Repair.";
    }


    public void purchaseWeapon() 
    {
        if (PlayerPrefs.GetFloat("Currency")-300 >=0)
        {
            PlayerPrefs.SetFloat("Currency",PlayerPrefs.GetFloat("Currency"));

            GameObject wepSlots = GameObject.Find("WeaponManager");


            if (toggle.GetComponent<Toggle>().isOn)
            {



                if (wepSlots.GetComponent<WeaponSlots>().activeWeapon == wepSlots.GetComponent<WeaponSlots>().slot2)
                {
                    wepSlots.GetComponent<WeaponSlots>().end();

                    wepSlots.GetComponent<WeaponSlots>().activeWeapon = wepSlots.GetComponent(forSale) as Weapon;
                }
                wepSlots.GetComponent<WeaponSlots>().slot2 = wepSlots.GetComponent(forSale) as Weapon;
            }
            else 
            {
                if (wepSlots.GetComponent<WeaponSlots>().activeWeapon == wepSlots.GetComponent<WeaponSlots>().slot1)
                {
                    wepSlots.GetComponent<WeaponSlots>().end();

                    wepSlots.GetComponent<WeaponSlots>().activeWeapon = wepSlots.GetComponent(forSale) as Weapon;
                }
                wepSlots.GetComponent<WeaponSlots>().slot1 = wepSlots.GetComponent(forSale) as Weapon;
            }
           
        }
    }

    public void purchaseHealth()
    {
        print("Current Money= " + PlayerPrefs.GetFloat("Currency") + " also cost is" + PlayerPrefs.GetFloat("HealthCost"));
        float check1 = PlayerPrefs.GetFloat("Currency");
        float check2 = PlayerPrefs.GetFloat("HealthCost");
        if ((check1 - check2) >= 0) 
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHit>().health+10  <= 100) 
            {
                print("healthbought");
                PlayerPrefs.SetFloat("Currency",PlayerPrefs.GetFloat("Currency") - PlayerPrefs.GetFloat("HealthCost")) ;
                GameObject p = GameObject.Find("Player");
                p.GetComponent<PlayerHit>().health += 10;
                p.GetComponent<PlayerHit>().healthBar.GetComponent<Image>().fillAmount = p.GetComponent<Hit>().health / 100;
                PlayerPrefs.SetFloat("HealthCost", PlayerPrefs.GetFloat("HealthCost") + 50);
                SetHealthText();
            }
            
        
        }
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
