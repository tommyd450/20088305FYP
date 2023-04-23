using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHelix : Weapon
{

    [SerializeField] GameObject projectile1;
    [SerializeField] GameObject projectile2;
    [SerializeField] GameObject Weapon;
    GameObject player;
    GameObject proj1;
    GameObject proj2;
    Coroutine auto;
    public AudioClip sfx;

    string name = "Helix Cannon";
    void Start()
    {
        player = GameObject.Find("Player");
        //playerBod = player.GetComponent<Rigidbody>();
        //projBody = projectile.GetComponent<Rigidbody>();
    }


    void Update()
    {
        player = GameObject.Find("Player");
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
        GetComponent<AudioSource>().PlayOneShot(sfx);
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
    // Start is called before the first frame update
    public override void attackInitiated()
    {
        auto = StartCoroutine(AutoFire());

    }

    // Update is called once per frame
    public override void attackReleased()
    {
        StopCoroutine(auto);
    }

    public override void stopCouroutine()
    {
        StopAllCoroutines();
    }

    public override string returnName()
    {
        return name;
    }
}
