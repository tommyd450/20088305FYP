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

        //Debug.Log("Position "+ _squad.Leader.transform.position);
        //Debug.Log("Forward " + _squad.Leader.transform.forward);
        //Debug.Log("Forwardnorm " + _squad.Leader.transform.forward.normalized);

        Vector3 pos = new Vector3(_squad.Leader.transform.position.x - (_squad.Leader.transform.forward.x* (5f+ (5f *formationIndex))), _squad.Leader.transform.position.y, _squad.Leader.transform.position.z - (_squad.Leader.transform.forward.z * (5f * formationIndex)));
        
        _agent.SetDestination(pos);
        //_agent.SetDestination(_squad.Leader.transform.position)

        return NodeState.SUCCESS;
    }
}
