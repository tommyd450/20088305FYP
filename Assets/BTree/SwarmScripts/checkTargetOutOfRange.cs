using System.Collections;
using System.Collections.Generic;
using BTree;
using UnityEngine;
using UnityEngine.AI;

public class checkTargetOutOfRange : Node
{

    private GameObject _player;
    private Transform _transform;
    private float _range;

    public checkTargetOutOfRange(GameObject player, Transform transform, float range)
    {
        _player = player;
        _transform = transform;
        _range = range;
    }



    public override NodeState Evaluate()
    {


        if (Vector3.Distance(_player.transform.position, _transform.position) > _range)
        {
            return NodeState.SUCCESS;
        }

        return NodeState.FAILURE;
    }

}
