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
    public ZombidData zombieData;

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
                    SoundManager.instance.PlaySoundEffect("Z_Attack");
                }
                else
                {
                    navMeshAgent.isStopped = false;
                    navMeshAgent.updatePosition = true;
                    StateAnim(ZombieAniState.Walk); // Walk
                    SoundManager.instance.PlaySoundEffect("Z_Move");
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
            SoundManager.instance.PlaySoundEffect("Z_Die");
        }
    }

    private void MoveStop()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.updatePosition = false;
    }

    public void ZombieMoveAniEvent()
    {
        navMeshAgent.isStopped = false;
    }

    public void GetHit(int damage)
    {
        navMeshAgent.updateRotation = false;
        navMeshAgent.updatePosition = false;

        Zombie zombie = gameObject.GetComponent<Zombie>();
        zombie.zombieData.Hp -= damage;
        StateAnim(ZombieAniState.GetHit);

        SoundManager.instance.PlaySoundEffect("Z_Hurt");
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
