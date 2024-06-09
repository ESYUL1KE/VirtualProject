using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    private int maxHealth = 100;

    private bool isDead;

    private void Awake()
    {
        isDead = false;
        health = maxHealth;
    }

    void Update()
    {
        Debug.Log("플레이어 현재 체력: " + health);

        if(isDead == true)
        {
            Die();
        }
    }

    public void GetHit(int damage)
    {
        // Sound 재생

        health -= damage;

        if (health <= 0)
        {
            isDead = true;
        }
    }

    void Die()
    {
        if (isDead != true)
            return;

        // Player Die Sound
        // GameOver UI 생성(GameManager) & Restart
    }
}
