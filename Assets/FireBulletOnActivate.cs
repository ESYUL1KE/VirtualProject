using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePosition;
    public float fireSpeed = 20f;

    void Start()
    {
        XRGrabInteractable grabble = GetComponent<XRGrabInteractable>();
        grabble.activated.AddListener(FireBullet);
    }

    private void FireBullet(ActivateEventArgs args)
    {
        // 사운드 재생
        GameObject spawnBullet = Instantiate(bullet);
        spawnBullet.transform.position = firePosition.position;
        spawnBullet.GetComponent<Rigidbody>().velocity = (firePosition.forward * -1) * fireSpeed;
        Destroy(spawnBullet,5f);
    }
}
