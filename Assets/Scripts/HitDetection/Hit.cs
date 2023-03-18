using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hit : MonoBehaviour
{
    public float timePassed { get; set; }
    public float health = 100;

    void Update()
    {
        timePassed += Time.deltaTime;   
    }

    public abstract void hit();
}
