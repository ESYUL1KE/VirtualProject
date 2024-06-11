using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    private Reload reload;
    public GameObject bullet;
    public Transform firePosition;
    public float fireSpeed = 20f;
    private XRGrabInteractable grabble;
    
    

    void Start()
    {
        grabble = GetComponent<XRGrabInteractable>();
        reload = GetComponent<Reload>();

        grabble.activated.AddListener(FireBullet);

        Quaternion gunRot = GetComponent<Gun>().transform.rotation;
        Debug.Log(gunRot);
    }

    private void FireBullet(ActivateEventArgs args)
    {
        SoundManager.instance.PlaySoundEffect("Fire");

        GameObject spawnBullet = Instantiate(bullet);

        spawnBullet.transform.position = firePosition.position;
     
        spawnBullet.GetComponent<Rigidbody>().velocity = (firePosition.forward * -1) * fireSpeed;

        reload.DiscountBullet();

        Destroy(spawnBullet, 2f);
    }

    public void AddListener()
    {
        grabble.activated.AddListener(FireBullet);
    }

    public void RemoveListener()
    {
        grabble.activated.RemoveListener(FireBullet);
    }
}
