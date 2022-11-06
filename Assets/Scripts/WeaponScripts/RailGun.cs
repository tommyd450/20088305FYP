using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailGun : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject Weapon;
    [SerializeField] GameObject chargeParticle;
    [SerializeField] GameObject chargeDispersal;
    GameObject tempPart;
    GameObject player;
    Rigidbody playerBod;
    Coroutine auto;
    private PlayerControls playerControls;
    float timeSince;
    float startTime;
    float cooldownStart;
    bool chargeComplete = false;
    void Start()
    {
        player = GameObject.Find("Player");
        playerBod = player.GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Controls.Shoot.started += _ => volley();
        playerControls.Controls.Shoot.canceled += _ => cease();
    }

    void Update()
    {
        
    }

    void volley()
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

    void cease()
    {
        if (Time.time - cooldownStart > 3 && chargeComplete==false)
        {
            chargeComplete = true;
            timeSince = Time.time - startTime;
            //print("Time Passed : "+timeSince);

            Destroy(tempPart);
            GameObject disperse = Instantiate(chargeDispersal);
            disperse.transform.parent = player.transform;
            disperse.transform.position = player.transform.position;
            Destroy(disperse, 2);

            Vector3 dir = new Vector3(player.transform.forward.x * 1000f, 0, player.transform.forward.z * 1000f).normalized;
            playerBod.velocity = new Vector3(0, 0, 0);
            playerBod.AddRelativeForce((playerBod.gameObject.transform.forward * 100f) * timeSince, ForceMode.Impulse);
            cooldownStart = Time.time;
        }
    }

    public void shoot()
    {
        /*
        Vector3 move = new Vector3(player.transform.forward.x, 0, player.transform.forward.z);
        GameObject proj = Instantiate(projectile, player.transform);
        proj.transform.SetParent(null, true);
        Quaternion temp = player.transform.rotation;
        temp.x = 0;
        temp.z = 0;
        proj.transform.rotation = temp;
        proj.transform.position = move;
        Destroy(proj, 5);
        */
    }

    /*
    public IEnumerator AutoFire()
    {
        while (true)
        {
            shoot();
            yield return new WaitForSeconds(5);
        }
    }
    */

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
