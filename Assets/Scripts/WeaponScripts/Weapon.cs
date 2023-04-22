using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    private PlayerControls playerControls;

    

    public abstract void attackInitiated();
    public abstract void attackReleased();

    public abstract void stopCouroutine();

    public abstract string returnName();
}
