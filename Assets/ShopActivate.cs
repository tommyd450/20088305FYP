using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopActivate : MonoBehaviour
{
    GameObject ui;
    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("UIManagement");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            ui.GetComponent<UIInGameManagement>().openShop();
        }
    }
}
