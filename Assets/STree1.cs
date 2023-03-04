using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;
using BTree;
public class STree1 : BHTree
{
    public GameObject player;
    public GameObject ai;
    NavMeshAgent nva;



    protected override Node SetupTree()
    {
        nva = ai.GetComponent<NavMeshAgent>();
        Node root = new PushToTarget(player, ai, nva);
        return root;
    }
}
