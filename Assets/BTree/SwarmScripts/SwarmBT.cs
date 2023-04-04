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

    public GameObject proj;

    [SerializeField] public GameObject[] squadron;



    private Transform fob;

    protected override Node SetupTree() 
    {
        timePassed += Time.deltaTime;
        Node root = new Sequence(new List<Node>
        {

            new LeaderElection(squadron,GetComponent<SquadManagement>()),

            new Selector(new List<Node>
            {
                

                new Sequence(new List<Node>
                {
                    new InSquadCheck(GetComponent<SquadManagement>()), // Checks if the object 
                    new Selector(new List<Node> 
                    {
                        new Sequence(new List<Node>
                        {
                            new checkTargetOutOfRange(player,this.transform,25),
                            new MoveToTarget(player, this.transform,GetComponent<NavMeshAgent>()),
                        }),
                        new Sequence(new List<Node>
                        {
                            new checkTargetinRange(player,this.transform,15),
                            new MoveAwayFromTarget(player,this.transform,GetComponent<NavMeshAgent>())
                        }),
                        
                    })

                }),
                new Sequence(new List<Node>
                {
                    new LeaderCheck(GetComponent<SquadManagement>()),
                    new FormationFlight(player,GetComponent<SquadManagement>(),GetComponent<NavMeshAgent>(),this.gameObject)
                }),

            }),
            new Sequence(new List<Node>
            {
                new checkTargetinRange(player,this.transform,50),
                new shootAtTarget(player,this.transform,timePassed,proj),
            }),
            
            





                /*new Sequence(new List<Node>
                {

                    new checkTargetinRange(player,this.transform,25),
                    new shootAtTarget(player,this.transform,timePassed)
                }),*/
           

           

        }); ; ; ;
        timePassed = 0;
        print("reset");


        return root;
    }
}
