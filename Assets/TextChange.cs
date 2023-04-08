using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextChange : MonoBehaviour
{
    Slider slider;
    public GameObject updateObject;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateText() 
    {
        updateObject.GetComponent<TextMeshProUGUI>().text = "" + slider.value + "";
    }
}
