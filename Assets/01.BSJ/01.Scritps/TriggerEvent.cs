using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    private Transform player;
    public Timer timer;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        timer = FindObjectOfType<Timer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject door = GameObject.Find("Door_Roof_LOD");
            if (gameObject.name == door.name)
            {
                return;
            }
            else
            {
                if (gameObject.transform.position.z > player.position.z)
                {
                    player.position = gameObject.transform.position + new Vector3(0f, 0f, 2.5f);
                }
                else if (gameObject.transform.position.z < player.position.z)
                {
                    player.position = gameObject.transform.position - new Vector3(0f, 0f, 2.5f);
                }
            }
        }

        if (other.gameObject.CompareTag("Key"))
        {
            GameObject door = GameObject.Find("Door_Roof_LOD");
            if (gameObject.name == door.name)
            {
                player.transform.position = new Vector3(1.0f, 13.6f, 0.46f);
                timer.GameEnd();
            }
        }
    }
}
