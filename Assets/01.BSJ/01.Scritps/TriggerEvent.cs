using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public Transform player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.transform.position.z > player.position.z)
            {
                player.position = gameObject.transform.position + new Vector3(0f, 0f, 3f);
            }
            else if (gameObject.transform.position.z < player.position.z)
            {
                player.position = gameObject.transform.position - new Vector3(0f, 0f, 3f);
            }
            Debug.Log("trigger");
        }
    }
}
