using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BTree;

public class FormationFlight : Node
{
    SquadManagement _squad;
    GameObject _player;
    NavMeshAgent _agent;
    GameObject _th;

    public FormationFlight(GameObject player, SquadManagement squad, NavMeshAgent agent, GameObject th) 
    {
        _squad = squad;
        _player = player;
        _agent = agent;
        _th = th;
    }

    public override NodeState Evaluate() 
    {
        float formationIndex = _squad.Leader.GetComponent<SquadManagement>().squadron.IndexOf(_th)+1;
        Vector3 pos;
        if (formationIndex == 1)
        {
            pos = _squad.Leader.transform.Find("Formation1").position;
            _agent.SetDestination(pos);
        }
        else if (formationIndex == 2)
        {
            pos = _squad.Leader.transform.Find("Formation2").position;
            _agent.SetDestination(pos);
        }
        else if (formationIndex == 3) 
        {
            pos = _squad.Leader.transform.Find("Formation3").position;
            _agent.SetDestination(pos);
        }
        
        
        //_agent.SetDestination(_squad.Leader.transform.position)

        return NodeState.SUCCESS;
    }
}
