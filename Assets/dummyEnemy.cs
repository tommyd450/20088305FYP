using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AI;
using UnityEngine;

public class dummyEnemy : MonoBehaviour
{
    GameObject player;
    NavMeshAgent nv;
    [SerializeField] GameObject proj;
    float dt;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        nv = GetComponent<NavMeshAgent>();
        dt = 0f;
    }

    // Update is called once per frame
    public void  Update()
    {
        
        dt += Time.deltaTime;
        move();
        if (dt > 3) 
        {
            dt = 0;
            GameObject g = Instantiate(proj,this.transform.position,this.transform.rotation);
            Rigidbody b;
            b = g.GetComponent<Rigidbody>();
            Vector3 dir = new Vector3(transform.forward.x, 0, transform.forward.z);
            b.AddForce(dir * 50, ForceMode.Impulse);
            Destroy(g,1);
        }
    }

    public async void move() 
    {
        nv.destination = player.transform.position;
    }
}
