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
    public GameObject progression;
    public GameObject shop;
    bool shopSpawned = false;


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
                int pointSelect = Random.Range(0, roomCoords.Length - 1);
                Vector3 pos = new Vector3(roomCoords[pointSelect].transform.position.x, 0, roomCoords[pointSelect].transform.position.z);
                enemies.Add(Instantiate(enemy, pos, Quaternion.identity));
                enemies.ElementAt(i).GetComponent<SwarmBT>().player = GameObject.Find("Player");
            }
        }
        int enemyNumber = GameObject.FindGameObjectsWithTag("SwarmType").Length;
        if (playerInRoom == true && spawned == true) 
        {
            if (enemyNumber <= 0)
            {
                if (GameObject.FindGameObjectsWithTag("Room").Length == 1)
                {
                    Vector3 pos = new Vector3(roomCoords[roomCoords.Length / 2].transform.position.x, 0, roomCoords[roomCoords.Length / 2].transform.position.z);
                    Instantiate(progression, pos, Quaternion.identity);
                }
                if (GameObject.FindGameObjectsWithTag("Room").Length == Mathf.Round((float)(roomManagement.caveDimens.Count) / 2) && shopSpawned == false) 
                {
                    shopSpawned = true;
                    Vector3 pos = new Vector3(roomCoords[roomCoords.Length / 2].transform.position.x, 0, roomCoords[roomCoords.Length / 2].transform.position.z);
                    Instantiate(shop, pos, Quaternion.identity);
                }
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
