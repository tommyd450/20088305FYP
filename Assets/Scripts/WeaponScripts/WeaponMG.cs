using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WeaponMG : Weapon
{
    public AudioClip sfx;
    GameObject player;
    [SerializeField] GameObject projectile;
    Coroutine auto;
    string name = "Auto Cannon";
    // Experimenting with inheritence not seeing the advantage rght now other than code hygiene.
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (player == null) 
        {
            player = GameObject.Find("Player");
        }
    }

    public override void attackInitiated()
    {
        print("Hello");
        auto = StartCoroutine(forCouroutine());
    }

// Update is called once per frame
    public override void attackReleased() 
    {
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
        makeNoise(); 
        Destroy(proj, 5);
    }



    public void makeNoise() 
    {
        
            
            GetComponent<AudioSource>().PlayOneShot(sfx);
        
    }

    public IEnumerator forCouroutine()
    {
        while (true)
        {
            shoot();
            yield return new WaitForSeconds(0.25f);
        }
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
