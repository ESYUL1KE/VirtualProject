using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 25;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            Zombie zombie = other.gameObject.GetComponent<Zombie>();
            zombie.GetHit(damage);
            Destroy(gameObject);
        }
    }

}
