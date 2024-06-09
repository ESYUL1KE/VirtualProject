using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health { get; private set; }

    private bool isDead;

    private void Awake()
    {
        isDead = false;
    }

    void Update()
    {
        
    }

    void GetHit()
    {
        /*health -= damage;*/

        if (health <= 0)
        {
            isDead = true;
            Die();
        }
    }

    void Die()
    {
        if (isDead != true)
            return;
    }
}
