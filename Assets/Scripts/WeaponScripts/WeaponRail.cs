using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRail : Weapon
{
    private PlayerControls playerControls;

    // Experimenting with inheritence not seeing the advantage rght now other than code hygiene.

    public override void Awake()
    {
        //playerControls = new PlayerControls();
        //playerControls.Controls.Shoot.started += _ => attackInitiated();
        //playerControls.Controls.Shoot.canceled += _ => attackReleased();
    }
    

    public override void attackInitiated()
    {
        print("HelloFreTest");
    }

    // Update is called once per frame
    public override void attackReleased()
    {

        print("HelloRelTest");
    }

    public  IEnumerator forCouroutine()
    {
        while (true)
        {
            //shoot();
            yield return new WaitForSeconds(0.06f);
        }
    }
    private void OnEnable()
    {
        playerControls.Enable();

    }

    private void OnDisable()
    {
        //playerControls.Controls.Shoot.performed -= ctx => shoot();
        playerControls.Disable();
    }
}
