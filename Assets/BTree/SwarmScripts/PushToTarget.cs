using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
using UnityEngine.AI;

using BTree;

public class PushToTarget : Node
{

    private GameObject _player;
    private GameObject _ai;
    private NavMeshAgent _nva;
    private bool _inRange = false;

    public PushToTarget(GameObject player, GameObject ai, NavMeshAgent nva) 
    {
        _player = player;
        _ai = ai;
        _nva = nva;
    }

    public override NodeState Evaluate() 
    {

        if (_inRange)
        {

            _nva.isStopped = true;
            state = NodeState.SUCCESS;

        }
        else 
        {
            if (_nva.destination != _player.transform.position)
            {
                _nva.SetDestination(_player.transform.position);
            }

            if (Vector3.Distance(_ai.transform.position, _player.transform.position) < 5) 
            {

                _inRange = true;
            }
        }


        state = NodeState.RUNNING;
        return state;
    }
}
