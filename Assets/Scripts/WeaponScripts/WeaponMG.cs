using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMG : Weapon
{
   
    GameObject player;
    [SerializeField] GameObject projectile;
    Coroutine auto;
    // Experimenting with inheritence not seeing the advantage rght now other than code hygiene.
    void Start()
    {
        player = GameObject.Find("Player");
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
        Destroy(proj, 5);
    }

  

    public IEnumerator forCouroutine()
    {
        while (true)
        {
            shoot();
            yield return new WaitForSeconds(0.06f);
        }
    }

    public override void stopCouroutine()
    {
        StopAllCoroutines();
    }




}
