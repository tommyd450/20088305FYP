using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BTree;

public class InSquadCheck : Node
{
    SquadManagement _squad;

    public InSquadCheck(SquadManagement squad) 
    {
        _squad = squad;
    }

    public override NodeState Evaluate() 
    {
        //Debug.Log("IsLeaderCheck");
        if (_squad.isLeader) 
        {
            return NodeState.SUCCESS;
        }

        return NodeState.FAILURE;
    }
}
