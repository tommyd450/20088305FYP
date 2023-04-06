using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
using System.Linq;

public class RoomManagement : MonoBehaviour
{
    public GameObject closer;
    public GameObject blocker;
    public GameObject caveNode;
    public GameObject room;
    public GameObject[] rooms;
    public GameObject player;

    // Start is called before the first frame update
    public CellularAutomata ca;
    public List<List<CellularAutomata.Node>> caveEntry;
    public List<List<CellularAutomata.Node>> caveDimens;




    public List<GameObject> doors;
    void Start()
    {
        
        ca = GameObject.Find("Generation").GetComponent<CellularAutomata>();
        caveEntry = ca.caveConnections;
        caveDimens = ca.actualCaves;
        caveDimens.RemoveAt(0);
        rooms = new GameObject[caveDimens.Count];

        Vector3 spawnPoint = new Vector3(caveDimens.ElementAt(0).ElementAt(0).x * 15, 1, caveDimens.ElementAt(0).ElementAt(0).y * 15);
        GameObject p = Instantiate(player, spawnPoint, Quaternion.identity);
        p.name = "Player";
        for (int i = 0; i < caveDimens.Count; i++) 
        {
            Vector3 pos = new Vector3(0, 0, 0);
            GameObject r = Instantiate(room, pos, Quaternion.identity);
            
            r.GetComponent<Room>().initRoom(caveDimens.ElementAt(i).Count, caveDimens.ElementAt(i));
            rooms[i] = r;
        }


        foreach (List<CellularAutomata.Node> x in caveEntry) 
        {
            
            
            Vector3 point = new Vector3(x.ElementAt(1).x*15, 0, x.ElementAt(1).y*15);
            GameObject g = Instantiate(blocker, point, Quaternion.identity);
           
            doors.Add(g);

            if (x.ElementAt(1).direction == CellularAutomata.DIR.NORTH)
            {
                //g.transform.position = point;
                g.transform.Rotate(-90, 0, 0);
            }
            else if (x.ElementAt(1).direction == CellularAutomata.DIR.SOUTH) 
            {
                //g.transform.position = point;
                g.transform.Rotate(-90, 180, 0);
            }
            else if (x.ElementAt(1).direction == CellularAutomata.DIR.EAST)
            {
                //g.transform.position = point;
                g.transform.Rotate(-90, 90, 0);

            }
            else if (x.ElementAt(1).direction == CellularAutomata.DIR.WEST)
            {
                //g.transform.position = point;
                g.transform.Rotate(-90, 359, 0);

            }
            Vector3 entry = new Vector3(x.ElementAt(0).x * 15, 0, x.ElementAt(0).y * 15);
            GameObject e = Instantiate(blocker, entry, Quaternion.identity);
           
            doors.Add(e);
            if (x.ElementAt(0).direction == CellularAutomata.DIR.NORTH)
            {
                //g.transform.position = point;
                e.transform.Rotate(-90,0, 0);
            }
            else if (x.ElementAt(0).direction == CellularAutomata.DIR.SOUTH)
            {
                //g.transform.position = point;
                e.transform.Rotate(-90, 180, 0);
            }
            else if (x.ElementAt(0).direction == CellularAutomata.DIR.EAST)
            {
                //g.transform.position = point;
                e.transform.Rotate(-90, 90, 0);

            }
            else if (x.ElementAt(0).direction == CellularAutomata.DIR.WEST)
            {
                //g.transform.position = point;
                e.transform.Rotate(-90, 359, 0);

            }



        }
        ca.nm.UpdateNavMesh(ca.nm.navMeshData);
    }

    public void closeAll() 
    {
        foreach(GameObject door in doors) 
        {
            door.GetComponent<MeshRenderer>().enabled = true;
            door.GetComponent<BoxCollider>().enabled = true;
            //ca.nm.UpdateNavMesh(ca.nm.navMeshData);
        }
    }

    public void openAll()
    {
        foreach (GameObject door in doors)
        {
            door.GetComponent<MeshRenderer>().enabled = false ;
            door.GetComponent<BoxCollider>().enabled = false;
            //ca.nm.UpdateNavMesh(ca.nm.navMeshData);
        }
    }


}
