using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Rigidbody rigid;
    Animator anim;

    public Transform target;
    public ZombidData zombieData;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        navMeshAgent.speed = zombieData.Speed;
        zombieData.Hp = zombieData.MaxHp;
    }

    private void Update()
    {
        if (zombieData.Hp > 0)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (distanceToTarget < zombieData.DetectionRagne)
            {
                anim.SetInteger("State", 2); // Walk
                navMeshAgent.SetDestination(target.position);

                if (distanceToTarget < zombieData.AttackRange)
                {
                    anim.SetInteger("State", 1); // Attack
                }
            }
            else
            {
                anim.SetInteger("State", 0); // Idle
            }
        }
        else
        {
            anim.SetBool("Live", false);
        }
    }

    //private void FreezeVelocity()
    //{
    //    rigid.velocity = Vector3.zero;
    //    rigid.angularVelocity = Vector3.zero;
    //}

    //private void FixedUpdate()
    //{
    //    FreezeVelocity();
    //}
}
