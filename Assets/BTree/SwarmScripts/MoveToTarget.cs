using System.Collections;
using System.Collections.Generic;
using BTree;
using UnityEngine;
using UnityEngine.AI;
public class MoveToTarget : Node
{

    private Transform _transform;
    private GameObject _player;
    private NavMeshAgent _agent;


    public MoveToTarget(GameObject player, Transform transform, NavMeshAgent agent) 
    {
        _transform = transform;
        _player = player;
        _agent = agent;
    }

    public override NodeState Evaluate() 
    {
        _agent.SetDestination(_player.transform.position);
        if (Vector3.Distance(_transform.position, _player.transform.position) <= 25)
        {
            
            //_agent.isStopped = true;
            return NodeState.SUCCESS;
        }
       // _agent.isStopped = false;
        



        
        

        return NodeState.FAILURE;
    }
}
