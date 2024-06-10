using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    private Reload reload;
    public GameObject bullet;
    public Transform firePosition;
    public float fireSpeed = 20f;

    void Start()
    {
        XRGrabInteractable grabble = GetComponent<XRGrabInteractable>();
        reload = GetComponent<Reload>();
        grabble.activated.AddListener(FireBullet);
    }

    private void FireBullet(ActivateEventArgs args)
    {
        if (!reload.isReload)
        {
            SoundManager.instance.PlaySoundEffect("Reload");
            StartCoroutine(reload.GunReload());
            return;
        }
        else
        {
            SoundManager.instance.PlaySoundEffect("Fire");
            GameObject spawnBullet = Instantiate(bullet);
            spawnBullet.transform.position = firePosition.position;
            spawnBullet.GetComponent<Rigidbody>().velocity = (firePosition.forward * -1) * fireSpeed;
            reload.DiscountBullet();
            Destroy(spawnBullet, 2f);
        }
    }
}
