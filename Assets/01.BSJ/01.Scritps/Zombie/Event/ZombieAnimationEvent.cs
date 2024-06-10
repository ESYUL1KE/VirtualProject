using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimationEvent : MonoBehaviour
{
    ZombieSound zombieSound;
    Zombie zombie;

    private void Start()
    {
        zombieSound = gameObject.GetComponent<ZombieSound>();
        zombie = gameObject.GetComponent<Zombie>();
    }

    public void IdleSound()
    {
        string[] idleArray = new string[] { "Z_Idle1" , "Z_Idle2" , "Z_Idle3" };
        int rndNum = Random.Range(0, idleArray.Length);

        zombieSound.PlaySoundEffect(idleArray[rndNum]);
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

    public void DieEvent()
    {
        gameObject.SetActive(false);
        GameManager.instance.zombie_Count++;
    }
}
