using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BTree;

public class LeaderElection : Node
{

    public GameObject[] squad;
    public SquadManagement _sm;
    public LeaderElection(GameObject[] sq,SquadManagement sm) 
    {
        squad = sq;
        _sm = sm;
    }

    public override NodeState Evaluate()
    {
        if(_sm.isFollower == false || _sm.isLeader == false) 
        {
            _sm.DetermineLeaderCandidate();
            return NodeState.SUCCESS;
        }


        return NodeState.SUCCESS;
    }
}
