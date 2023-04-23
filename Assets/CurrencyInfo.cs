using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Currency : " + PlayerPrefs.GetFloat("Currency");
    }
}
