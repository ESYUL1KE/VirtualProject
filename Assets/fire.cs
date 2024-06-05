using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public Transform firePos; 
    
        
    // Update is called once per frame
    void Update()
    {
        Vector3 shotPos = firePos.TransformDirection(Vector3.forward * 10);
        Debug.DrawRay(firePos.transform.position, shotPos, Color.red);
    }
}
