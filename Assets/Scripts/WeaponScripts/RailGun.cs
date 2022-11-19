using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailGun : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject Weapon;
    [SerializeField] GameObject chargeParticle;
    [SerializeField] GameObject chargeDispersal;
    [SerializeField] GameObject tempPart;
    [SerializeField] GameObject player;
    Rigidbody playerBod;
    private PlayerControls playerControls;
    float timeSince;
    float startTime;
    float cooldownStart;
    bool chargeComplete = false;
    RailProj rail;
    void Start()
    {
        player = GameObject.Find("Player");
        playerBod = player.GetComponent<Rigidbody>();
        rail = new RailProj();
    }

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Controls.Shoot.started += _ => charge();
        playerControls.Controls.Shoot.canceled += _ => release();
    }

    void Update()
    {
        
    }

    void charge()
    {
        startTime = Time.time;
        print(Time.time - cooldownStart);
        if (Time.time - cooldownStart > 3 && chargeComplete==true)
        {
            tempPart = Instantiate(chargeParticle);
            tempPart.transform.parent = player.transform;
            tempPart.transform.position = player.transform.position;
            chargeComplete = false;
        }
    }

    void release()
    {
        if (Time.time - cooldownStart > 3 && chargeComplete==false) // Ensures that the Cooldown of 3 seconds has been met.
        {
            chargeComplete = true;
            timeSince = Time.time - startTime; // Calculates Time since the charge was started 
            //print("Time Passed : "+timeSince);

            Destroy(tempPart); // Destroys the particle effect from the charge sequence
            GameObject disperse = Instantiate(chargeDispersal); // Creates the dispersal effect to denote the charge up is done and the projectile is spwaned

            disperse.transform.parent = player.transform; //Sets positions to that of the player
            disperse.transform.position = player.transform.position;
            Destroy(disperse, 2);


            // This section is responsible for the players knockback recieved from using the railgun 
            //Vector3 dir = new Vector3(player.transform.forward.x * 1000f, 0, player.transform.forward.z * 1000f).normalized;
            playerBod.velocity = new Vector3(0, 0, 0);
            playerBod.AddRelativeForce((playerBod.gameObject.transform.forward * 100f) * timeSince, ForceMode.Impulse);
            cooldownStart = Time.time;



            Vector3 move = new Vector3(player.transform.forward.x, 0, player.transform.forward.z).normalized;
            GameObject proj = Instantiate(projectile, player.transform);
            proj.transform.SetParent(null, true);
            Quaternion temp = player.transform.rotation;
            temp.x = 0;
            temp.z = 0;
            proj.transform.rotation = temp;
            proj.transform.position = move;
            proj.GetComponent<RailProj>().chargeMult = timeSince;
            Destroy(proj, 5);
            
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
