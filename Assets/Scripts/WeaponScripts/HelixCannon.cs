using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixCannon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject projectile1;
    [SerializeField] GameObject projectile2;
    [SerializeField] GameObject Weapon;
    GameObject player;
    GameObject proj1;
    GameObject proj2;
    Coroutine auto;
    bool flip;
    private PlayerControls playerControls;
    void Start()
    {
        player = GameObject.Find("Player");
        //playerBod = player.GetComponent<Rigidbody>();
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

        proj1 = Instantiate(projectile1, player.transform);
        proj2 = Instantiate(projectile2, player.transform);
        proj1.transform.SetParent(null, true);
        proj2.transform.SetParent(null, true);
        Quaternion temp = player.transform.rotation;
        temp.x = 0;
        temp.z = 0;
        proj1.transform.rotation = temp;
        proj1.transform.position = move;
        proj2.transform.rotation = temp;
        proj2.transform.position = move;
        Destroy(proj1, 5);
        Destroy(proj2, 5);
    }

    public IEnumerator AutoFire()
    {
        while (true)
        {
            shoot();
            yield return new WaitForSeconds(0.10f);
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
