using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
            if (x != this.gameObject && candidates.Count() <3) 
            {
                candidates.Add(x);
            }
            
        }
        Debug.Log("Squadron Size : " + candidates.Count());
        for (int i = 0; i< candidates.Count();i++) 
        {
            GameObject x = candidates.ElementAt(i); 
            if ( x.GetComponent<SquadManagement>().isLeader == false && x.GetComponent<SquadManagement>().isFollower == false ) 
            {
                
                Debug.Log("SQSIZE " + squadron.Count());
                squadron.Add(x);
                x.GetComponent<SquadManagement>().isFollower = true;
                x.GetComponent<SquadManagement>().Leader = this.gameObject;
                isLeader = true;
                
            }

        }
    }
}
