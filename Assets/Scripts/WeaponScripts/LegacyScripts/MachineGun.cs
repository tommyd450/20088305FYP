
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject Weapon;
    GameObject player;
    Rigidbody projBody;
    Rigidbody playerBod;
    Coroutine auto;
    private PlayerControls playerControls;
    void Start()
    {
        player = GameObject.Find("Player");
        playerBod = player.GetComponent<Rigidbody>();
        //projBody = projectile.GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Controls.Shoot.started += _ => volley();
        playerControls.Controls.Shoot.canceled += _ => cease();
    }

    void Update()
    {
        player = GameObject.Find("Player");
    }

    void volley()
    {
        auto = StartCoroutine(AutoFire());
    }

    void cease()
    {
        print("Yup");
        StopCoroutine(auto);
    }

    public void shoot()
    {
        Vector3 move = new Vector3(player.transform.forward.x, 0, player.transform.forward.z);

        GameObject proj = Instantiate(projectile, player.transform);
        proj.transform.SetParent(null, true);
        Quaternion temp = player.transform.rotation;
        temp.x = 0;
        temp.z = 0;
        proj.transform.rotation = temp;
        proj.transform.position = move;
        Destroy(proj, 5);
    }

    public IEnumerator AutoFire()
    {
        while (true)
        {
            shoot();
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
