using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BTree;

public class LeaderCheck : Node
{
    SquadManagement _squad;

    public LeaderCheck(SquadManagement squad)
    {
        _squad = squad;
    }

    public override NodeState Evaluate()
    {
        //Debug.Log("IsFollower");
        if (_squad.isFollower)
        {
            
            return NodeState.SUCCESS;
        }

        return NodeState.FAILURE;
    }
}
