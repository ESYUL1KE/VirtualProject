using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    public int bulletCount = 7;
    public bool isReload = false;

    private void Start()
    {
        bulletCount = 7;
    }

    public void DiscountBullet()
    {
        bulletCount--;
    }

    public IEnumerator GunReload()
    {
        if (bulletCount <= 0)
        {
            // reload UI
            SoundManager.instance.PlaySoundEffect("Reload");
            yield return new WaitForSeconds(3f);
            bulletCount = 7;
        }
    }
}
