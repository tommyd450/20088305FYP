using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class SquadManagement: MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> squadron = new List<GameObject>();
    public bool isLeader;
    public GameObject Leader;
    public bool isFollower;
    public int squadSize = 0;

    public void DetermineLeaderCandidate() 
    {
        GameObject[] cand = GameObject.FindGameObjectsWithTag("SwarmType");
        List<GameObject> candidates = new List<GameObject>();

        foreach (GameObject x in cand) 
        {
            if ( x.GetComponent<SquadManagement>().Leader==null && x.GetComponent<SquadManagement>().isLeader == false && x.GetComponent<SquadManagement>().isFollower == false) 
            {
                candidates.Add(x);
            }
            
        }
        //Debug.Log("Squadron Size : " + candidates.Count());
        for (int i = 0; i< candidates.Count();i++) 
        {
            GameObject x = candidates.ElementAt(i); 
            
            //Debug.Log("SQSIZE " + squadron.Count());
            if (isFollower == false && x!=this.gameObject && squadron.Count() < 3 && x.GetComponent<SquadManagement>().isLeader==false && x.GetComponent<SquadManagement>().isFollower == false) 
            {
                NavMeshAgent nm = x.GetComponent<NavMeshAgent>();
                x.GetComponent<SquadManagement>().isFollower = true;
                x.GetComponent<SquadManagement>().Leader = this.gameObject;
                nm.acceleration = 175;
                nm.angularSpeed = 250;
                nm.speed = 175;
                nm.stoppingDistance = 10;
                nm.autoBraking = true;
                isLeader = true;
                squadron.Add(x);
            }
        }
    }

    public void PassingTheTorch() 
    {
        foreach (GameObject x in squadron) 
        {
            if (x != null)
            {
                NavMeshAgent nm = x.GetComponent<NavMeshAgent>();
                x.GetComponent<SquadManagement>().isFollower = false;
                x.GetComponent<SquadManagement>().Leader = null;
                nm.acceleration = 100;
                nm.angularSpeed = 200;
                nm.speed = 100;
                nm.stoppingDistance = 0;
                nm.autoBraking = false;
            }
        }
    }
}
