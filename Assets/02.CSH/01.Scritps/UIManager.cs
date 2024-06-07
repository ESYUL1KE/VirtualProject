using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    public Toggle[] toggles;
    public GameObject[] objectsToInstantiate;

    public Text nBullets;
    public Text nGrenades;

    private Color bulletoriginalColor = Color.white;
    private Color grenadeoriginalColor = Color.white;

    private int previousBulletCount;
    private int previousGrenadeCount;  

    //임시 데이터 지울 것 **********************
    private int bullets = 30, magazines = 5, grenades = 10, maxbullets = 90;
    //*****************************************



    public void OnStartButtonClicked()
    {
 
    }

    void Awake()
    {
        nBullets.text = bullets.ToString();
        nGrenades.text = grenades.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bullets != previousBulletCount)
        {
            UpdateTextBulletColor();
            previousBulletCount = bullets; 
        }

        if (grenades != previousGrenadeCount)
        {
            UpdateTextGrenadeColor();
            previousBulletCount = grenades;
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(bullets > 0)
            {
                bullets--;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            maxbullets -= 30 - bullets;
            bullets = 30;

        }

    }

    void UpdateTextBulletColor()
    {
        if (bullets == 0)
        {
            nBullets.color = Color.red;
            nBullets.text = bullets.ToString();
        }
        else
        {
            nBullets.color = bulletoriginalColor;
            nBullets.text = bullets.ToString();

        }

    }

    void UpdateTextGrenadeColor()
    {
        if (grenades == 0)
        {
            nGrenades.color = Color.red;
            nGrenades.text = grenades.ToString();
        }
        else
        {
            nGrenades.color = grenadeoriginalColor;
            nGrenades.text = grenades.ToString();
        }

    }

    public void StartGameScene()
    {
        SceneManager.LoadScene("CSH");
    }
}
