using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public Transform target;
    public float zombieRange = 5f;

    NavMeshAgent navMeshAgent;
    Rigidbody rigid;
    Animator anim;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (navMeshAgent.remainingDistance < zombieRange)
        {
            navMeshAgent.SetDestination(target.position);
            anim.SetInteger("State", 2);    // Walk
        }
        else if (navMeshAgent.remainingDistance < 0.1f)
        {
            anim.SetInteger("State", 1);    // Attack
        }
        else
        {
            anim.SetInteger("State", 0);    // Idle
        }
    }

    private void FreezeVelocity()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    private void FixedUpdate()
    {
        FreezeVelocity();
    }
}
