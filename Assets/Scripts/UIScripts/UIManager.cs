using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Pause()
    {
        Time.timeScale = 0;
    }

    void Resume() 
    {
        Time.timeScale = 1;
    }
}
