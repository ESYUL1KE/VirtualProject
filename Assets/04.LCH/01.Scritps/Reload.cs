using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Reload : MonoBehaviour
{
    public Image cooldown;
    public Text bullet;

    public float waitTime = 2.0f;
    private float currentTime = 0f;

    public int bulletCount = 7;

    private bool reloadSoundPlayed = false; // Flag to track if reload sound has been played

    private void Start()
    {
        bulletCount = 7;
        cooldown.enabled = false;
    }

    public void DiscountBullet()
    {
        bulletCount--;
    }

    void Update()
    {
        bullet.text = bulletCount.ToString();

        if (bulletCount <= 0)
        {
            StartCooldown();
        }
    }

    public void StartCooldown()
    {
        cooldown.enabled = true;

        FireBulletOnActivate fire = GetComponent<FireBulletOnActivate>();
        fire.RemoveListener();

        if (!reloadSoundPlayed) // Play reload sound only if it hasn't been played yet
        {
            SoundManager.instance.PlaySoundEffect("Reload");
            reloadSoundPlayed = true; // Set flag to true indicating reload sound has been played
        }

        currentTime += Time.deltaTime;
        cooldown.fillAmount = currentTime / waitTime;

        if (currentTime >= waitTime)
        {
            currentTime = 0f;
            bulletCount = 7;
            reloadSoundPlayed = false; // Reset the flag for the next reload

            fire.AddListener();
            cooldown.enabled = false;
        }
    }
}
