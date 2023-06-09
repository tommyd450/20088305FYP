using System.Collections;
using System.Collections.Generic;
using BTree;
using UnityEngine;
using UnityEngine.AI;

public class shootAtTarget : Node
{
    private float shootTimer = 1.5f;
    private float _timePassed;
    private GameObject _player;
    private Transform _transform;
    public GameObject _projectile;
    private AudioSource _audio;
    float timeP;

    public shootAtTarget(GameObject player, Transform transform,float timePassed, GameObject projectile,AudioSource audio)
    {
        _player = player;
        _transform = transform;
        _timePassed = timePassed;
        _projectile = projectile;
        _audio = audio;
    }



    public override NodeState Evaluate()
    {
        timeP += Time.deltaTime;
        Debug.Log(timeP);
        if (timeP > shootTimer)
        {

            Debug.Log("BANG");
            GameObject proj = GameObject.Instantiate(_projectile,_transform.position,Quaternion.identity);
            Vector3 direction = (_player.transform.position- _transform.position).normalized;
            proj.GetComponent<Rigidbody>().AddForce(direction * 150, ForceMode.Impulse);
            _audio.PlayOneShot(_audio.clip);
            timeP = 0;
            return NodeState.SUCCESS;
        }
        else 
        {
            
        }

        Debug.Log("Not Ready to Shoot Yet");
        return NodeState.RUNNING;
    }
}
