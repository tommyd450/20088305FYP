using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BTree;
using UnityEngine.AI;

public class MoveAwayFromTarget : Node
{
    private Transform _transform;
    private GameObject _player;
    private NavMeshAgent _agent;
   
    public MoveAwayFromTarget(GameObject player, Transform transform, NavMeshAgent agent) 
    {
        _transform = transform;
        _player = player;
        _agent = agent;
    }

    public override NodeState Evaluate() 
    {

        if (Vector3.Distance(_transform.position, _player.transform.position) > 15)
        {

            return NodeState.SUCCESS;
        }

        Vector3 runAway = _transform.position - _player.transform.position;
        Vector3 pos = _transform.position + runAway;

        if (Vector3.Distance(_transform.position, _player.transform.position) < 5) 
        {
            pos = _transform.position - runAway;
            _agent.SetDestination(pos);
            return NodeState.RUNNING;
        }

        

        //Debug.Log("Problem here in moveAway");



        _agent.SetDestination(pos);
        
        return NodeState.RUNNING;
        
        
        
    }
}
