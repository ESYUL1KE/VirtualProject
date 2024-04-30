using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;

    float countdown;
    bool hasExploded = false;

    void Start()
    {
        countdown = delay;
        
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded)
        {
            Exploded();
            hasExploded = true;
        }
    }

    private void Exploded()
    {
        Debug.Log("Boom!");
    }
}
