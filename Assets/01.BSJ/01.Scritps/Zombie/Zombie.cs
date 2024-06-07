using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public enum ZombieAniState
{
    Idle = 0,
    Attack = 1,
    Walk = 2,
    Hurt = 3,
    Die
}

public class Zombie : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator anim;
    private Rigidbody rb;
    private ZombieSound zombieSound;

    public Transform target;

    [SerializeField] private int hp;
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
        rb = GetComponent<Rigidbody>();
        zombieSound = GetComponent<ZombieSound>();

        this.navMeshAgent.updatePosition = false;
        this.navMeshAgent.updateRotation = false;

        this.navMeshAgent.speed = speed;
        hp = maxHp;

        StateAnim(ZombieAniState.Idle);
    }


    private void Update()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        
        if (hp > 0 && isLive)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            MoveStop();

            if (distanceToTarget < detectionRagne)
            {
                if (distanceToTarget < attackRange)
                {
                    StateAnim(ZombieAniState.Attack);    // Attack
                }
                else
                {
                    MovePossible();
                    StateAnim(ZombieAniState.Walk); // Walk
                    this.navMeshAgent.SetDestination(target.position);
                }
            }
            else if (state != ZombieAniState.Hurt || state != ZombieAniState.Die)
            {
                StateAnim(ZombieAniState.Idle); // Idle
            }
        }
    }

    public void MoveStop()
    {
        this.navMeshAgent.isStopped = true;
        this.navMeshAgent.updatePosition = false;
        this.navMeshAgent.updateRotation = false;
    }

    public void MovePossible()
    {
        this.navMeshAgent.isStopped = false;
        this.navMeshAgent.updatePosition = true;
        this.navMeshAgent.updateRotation = true;
    }

    public void GetHit(int damage)
    {
        hp -= damage;

        if (hp > 0)
        {
            StateAnim(ZombieAniState.Hurt);
        }
        else
        {
            Die();
        }

        Debug.Log($"After GetHit - HP: {hp}, IsLive: {isLive}");
    }

    public void Die()
    {
        isLive = false;

        StateAnim(ZombieAniState.Die);
    }

    public int TakeDamage()
    {
        zombieSound.PlaySoundEffect("Z_Attack");
        return damage;
    }

    public void AnimationInit()
    {
        StateAnim(ZombieAniState.Idle);
    }

    public void StateAnim(ZombieAniState zombieState)
    {
        if (zombieState == ZombieAniState.Die || zombieState == ZombieAniState.Hurt)
        {
            MoveStop();

            string aniState;
            if (zombieState == ZombieAniState.Die)
                aniState = "Die";
            else
                aniState = "Hurt";

            anim.SetTrigger(aniState);
            return;
        }
        else
        {
            state = zombieState;

            if (zombieState == ZombieAniState.Attack || zombieState == ZombieAniState.Idle)
            {
                MoveStop();
            }
            else if (zombieState == ZombieAniState.Walk)
            {
                MovePossible();
            }

            anim.SetInteger("State", (int)state);
            return;
        }
    }
}