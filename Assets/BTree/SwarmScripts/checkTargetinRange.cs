using System.Collections;
using System.Collections.Generic;
using BTree;
using UnityEngine;
using UnityEngine.AI;

public class checkTargetinRange : Node
{

    private GameObject _player;
    private Transform _transform;
    private float _range;

    public checkTargetinRange(GameObject player,Transform transform,float range) 
    {
        _player = player;
        _transform = transform;
        _range = range;
    }



    public override NodeState Evaluate() 
    {
        if (Vector3.Distance(_player.transform.position,_transform.position)<_range && Vector3.Distance(_player.transform.position, _transform.position) > 5) 
        {
            return NodeState.SUCCESS;
        }

        return NodeState.FAILURE;
    }
    
}
