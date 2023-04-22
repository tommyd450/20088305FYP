using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextChange : MonoBehaviour
{
    Slider slider;
    public GameObject updateObject;
    bool check = false;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        
    }


    void Update()
    {
        if (updateObject != null && check == false)
        {
            updateObject.GetComponent<TextMeshProUGUI>().text = "" + ((int)((slider.value) * 100)) + "";
            check = true;
        }
    }
    // Update is called once per frame


    public void updateText() 
    {
        if (updateObject != null && slider!=null)
        {
            updateObject.GetComponent<TextMeshProUGUI>().text = "" + ((int)((slider.value) * 100)) + "";
        }
    }
}
