using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
    public Image cooldown;

    public float waitTime = 2.0f;
    private float currentTime = 0f;

    private bool isCooldownStarted = false;

    void Update()
    {
        if (isCooldownStarted)
        {
            currentTime += Time.deltaTime;
            cooldown.fillAmount = currentTime / waitTime;

            if (currentTime >= waitTime)
            {
                isCooldownStarted = false;
                currentTime = 0f;
            }
        }
    }

    public void StartCooldown()
    {
        isCooldownStarted = true;
    }
}
