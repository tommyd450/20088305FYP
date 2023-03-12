using System.Collections;
using System.Collections.Generic;
using BTree;
using UnityEngine;
using UnityEngine.AI;

public class shootAtTarget : Node
{
    private float shootTimer = 3f;
    private float _timePassed;
    private GameObject _player;
    private Transform _transform;

    public shootAtTarget(GameObject player, Transform transform,float timePassed)
    {
        _player = player;
        _transform = transform;
        _timePassed = timePassed;
    }



    public override NodeState Evaluate()
    {

        if (_timePassed > shootTimer)
        {

            Debug.Log("BANG");
            return NodeState.SUCCESS;
        }
        else 
        {
            _timePassed += Time.deltaTime;
        }

        Debug.Log("Not Ready to Shoot Yet");
        return NodeState.RUNNING;
    }
}
