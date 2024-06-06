using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimationEvent : MonoBehaviour
{
    ZombieSound zombieSound;

    private void Start()
    {
        zombieSound = gameObject.GetComponent<ZombieSound>();
    }

    public void IdleSound()
    {
        zombieSound.PlaySoundEffect("Z_Idle");
    }
    public void AttackSound()
    {
        zombieSound.PlaySoundEffect("Z_Attack");
    }
    public void MoveSound()
    {
        zombieSound.PlaySoundEffect("Z_Move");
    }
    public void HurtSound()
    {
        zombieSound.PlaySoundEffect("Z_Hurt");
    }
    public void DieSound()
    {
        zombieSound.PlaySoundEffect("Z_Die");
    }
}
