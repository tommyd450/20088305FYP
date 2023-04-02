using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Room : MonoBehaviour
{
    public bool playerInRoom = false;
    bool spawned = false;
    public GameObject enemy;
    public GameObject roomSpace;
    public GameObject[] roomCoords;
    public List<GameObject> enemies;
    public RoomManagement roomManagement;
    public GameObject player;


    public void initRoom(int size, List<CellularAutomata.Node> rm)
    {
        roomCoords = new GameObject[size];
        

        
        for (int i = 1; i < rm.Count; i++) 
        {
            Vector3 pos = new Vector3(rm.ElementAt(i).x *15, 0, rm.ElementAt(i).y*15);
            GameObject r = Instantiate(roomSpace, pos, Quaternion.identity,this.transform);
            roomCoords[i] = r;
        }
        
    }

    void Start()
    {
        roomManagement = GameObject.Find("RoomManagemnt").GetComponent<RoomManagement>();
        enemies = new List<GameObject>();
    }

    void Update()
    {
        
        if (playerInRoom == true && spawned == false) 
        {
            int enemyAmount = Random.Range(4, 12);
            roomManagement.closeAll();
            spawned = true;
            for (int i = 0; i < enemyAmount; i++)
            {
                
                Vector3 pos = new Vector3(roomCoords[roomCoords.Length / 2].transform.position.x, 0, roomCoords[roomCoords.Length / 2].transform.position.z);
                enemies.Add(Instantiate(enemy, pos, Quaternion.identity));
                enemies.ElementAt(i).GetComponent<SwarmBT>().player = GameObject.Find("Player");
            }
        }
        int enemyNumber = GameObject.FindGameObjectsWithTag("SwarmType").Length;
        if (playerInRoom == true && spawned == true) 
        {
            if (enemyNumber <= 0)
            {
                foreach (GameObject p in roomCoords) 
                {
                    Destroy(p);
                }
                
                roomManagement.openAll();
                Destroy(this.gameObject,5);
            }
        }
        
    }


}
