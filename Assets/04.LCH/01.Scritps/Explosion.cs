using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosion;

    float delay;

    bool isExplode;


    void Start()
    {
        delay = 0;
        isExplode = false;
    }

    void Update()
    {
        delay += Time.deltaTime;
        if (!isExplode)
        {
            Explode();
        }
    }


    void Explode()
    {
        // delay�� 5�� �̻�Ǹ�
        if(delay >= 3f)
        {
            Boom();
            isExplode = true;
            Destroy(gameObject);
        }
    }

    void Boom()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }
}
