using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Animator anim;

    public Transform target;
    public ZombieData zombieData;

    ZombieAniState state;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        navMeshAgent.updatePosition = false;
        navMeshAgent.updateRotation = false;
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

            navMeshAgent.SetDestination(target.position);
            navMeshAgent.updateRotation = true;
            navMeshAgent.updatePosition = false;

            if (distanceToTarget < zombieData.DetectionRagne)
            {
                if (distanceToTarget < zombieData.AttackRange)
                {
                    MoveStop();
                    StateAnim(ZombieAniState.Attack);    // Attack
                }
                else
                {
                    navMeshAgent.isStopped = false;
                    navMeshAgent.updatePosition = true;
                    StateAnim(ZombieAniState.Walk); // Walk
                    navMeshAgent.SetDestination(target.position);
                }
            }
            else
            {
                StateAnim(ZombieAniState.Idle);    // Idle
                MoveStop();
            }
        }
        else
        {
            MoveStop();
            StateAnim(ZombieAniState.Die);
        }
    }

    private void MoveStop()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.updatePosition = false;
    }

    public void ZombieMovePossible()
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.updatePosition = true;
        navMeshAgent.updateRotation = true;
    }

    public void GetHit(int damage)
    {
        navMeshAgent.updateRotation = false;
        navMeshAgent.updatePosition = false;

        Zombie zombie = gameObject.GetComponent<Zombie>();
        zombie.zombieData.Hp -= damage;
        StateAnim(ZombieAniState.GetHit);
    }

    public int TakeDamage()
    {
        Zombie zombie = gameObject.GetComponent<Zombie>();
        int damage = zombie.zombieData.Damage;

        return damage;
    }

    public void Animinit()
    {
        StateAnim(ZombieAniState.Idle);
        navMeshAgent.updateRotation = true;
        navMeshAgent.updatePosition = true;
    }

    private void StateAnim(ZombieAniState zombieState)
    {
        if (zombieState == ZombieAniState.Die)
        {
            anim.SetBool("Live", false);
        }
        else
        {
            state = zombieState;
            anim.SetInteger("State", (int)state);
        }
    }

    private enum ZombieAniState
    {
        Idle = 0,
        Attack = 1,
        Walk = 2,
        GetHit = 3,
        Die
    }
}
