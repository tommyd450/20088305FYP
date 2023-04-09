using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //this.transform.rotation = Quaternion.Euler(0, ((this.gameObject.transform.rotation.y + 10) ), 0);
        this.transform.Rotate(new Vector3(0,(this.transform.rotation.y+5)*Time.deltaTime,0));
    }
}
