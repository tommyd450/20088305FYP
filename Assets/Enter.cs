using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour
{
    BoxCollider bx;
    RoomManagement rm;
    
    void Start()
    {
        bx = GetComponent<BoxCollider>();
        rm = GameObject.Find("RoomManagemnt").GetComponent<RoomManagement>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player") && GetComponentInParent<Room>().playerInRoom ==false)
        {
            GetComponentInParent<Room>().playerInRoom = true;
        }
    }
}
