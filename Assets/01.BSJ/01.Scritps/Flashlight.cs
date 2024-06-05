using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private GameObject flashlight;
    private bool flashlightActive = false;

    void Start()
    {
        flashlight.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!flashlightActive)
            {
                flashlight.SetActive(true);
                flashlightActive = true;
            }
            else
            {
                flashlight.SetActive(false);
                flashlightActive = false;
            }
        }
        
    }
}
