using System.Collections;
using System.Collections.Generic;
using BTree;
using UnityEngine;
using UnityEngine.AI;

public class SwarmBT : BTree.Tree
{
    // Start is called before the first frame update
    public static float speed = 2f;
    public float timePassed;
    public GameObject player;



    private Transform fob;

    protected override Node SetupTree() 
    {
        timePassed += Time.deltaTime;
        Node root = new Selector(new List<Node>
        {

            new Selector(new List<Node>
            {
                new Sequence(new List<Node>
                {
                    new checkTargetinRange(player,this.transform,25),
                    new MoveAwayFromTarget(player,this.transform,GetComponent<NavMeshAgent>())
                }),
                new Sequence(new List<Node>
                {
                    new checkTargetOutOfRange(player,this.transform,25),
                    new MoveToTarget(player, this.transform,GetComponent<NavMeshAgent>()),

                }),
                

            }),
                
                
            


            new Sequence(new List<Node>
            {

                new checkTargetinRange(player,this.transform,25),
                new shootAtTarget(player,this.transform,timePassed)
            }),
                
            
            
           
        }); ;
        timePassed = 0;
        print("reset");


        return root;
    }
}
