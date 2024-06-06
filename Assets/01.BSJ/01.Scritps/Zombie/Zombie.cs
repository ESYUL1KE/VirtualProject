using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator anim;

    public Transform target;

    private int hp;
    public int maxHp = 100;
    public int damage = 20;
    public int speed = 2;
    public int detectionRagne = 5;
    public int attackRange = 1;

    private bool isLive = true;

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
        navMeshAgent.speed = speed;
        hp = maxHp;
    }

    private void Update()
    {
        if (hp > 0 && isLive)
        {
            if (Input.GetKeyUp(KeyCode.D) && isLive)
            {
                GetHit(100);
            }

            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            navMeshAgent.SetDestination(target.position);
            navMeshAgent.updateRotation = true;
            navMeshAgent.updatePosition = false;

            if (distanceToTarget < detectionRagne)
            {
                if (distanceToTarget < attackRange)
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
        if (!isLive)
            return;

        navMeshAgent.updateRotation = false;
        navMeshAgent.updatePosition = false;

        hp -= damage;

        if (hp > 0 && isLive)
        {
            StateAnim(ZombieAniState.GetHit);
        }
        else
        {
            hp = 0;
            isLive = false;
            Die();
        }
    }

    public void Die()
    {
        if (isLive)
            return;

        MoveStop();
        StateAnim(ZombieAniState.Die);
    }

    public int TakeDamage()
    {
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
