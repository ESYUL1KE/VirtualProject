using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text[] timeText;

    public Text ZombieCount;
    public Text TimeCountMin;
    public Text TimeCountSec;

    public GameObject gameOverUI;
    public GameObject gameEndUI;
    
    public static float time = 420; // 제한 시간 120초
    public static float lefttime = 0;
    private bool isGameEnd = false;
    private bool isGameOver = false;
    int min, sec;

    //임시 data *****************
    public int zombiesdata = 0;
    public float timedata = 0;
    //**************************
    

    void Start()
    {
        //제한 시간 02:00
        timeText[0].text = "07";
        timeText[1].text = "00";

    }

    void Update()
    {
        if (!isGameEnd && !isGameOver)
        {


            if (time == 0)
            {
                isGameOver = true;
            }
            else
            {
                time -= Time.deltaTime;
                lefttime += Time.deltaTime;

                min = (int)time / 60;
                sec = ((int)time - min * 60) % 60;

                if (min <= 0 && sec <= 0)
                {
                    timeText[0].text = 0.ToString();
                    timeText[1].text = 0.ToString();
                }

                else
                {
                    if (sec >= 60)
                    {
                        min += 1;
                        sec -= 60;
                    }
                    else
                    {
                        timeText[0].text = min.ToString();
                        timeText[1].text = sec.ToString();
                    }
                }
            }
        }

       
        



    }

    void GameOver()
    {
        gameOverUI.SetActive(true);
        StartCoroutine(ReloadSceneAfterDelay(5f));
    }

    void GameEnd()
    {
        int elapsedMin = (int)time / 60;
        int elapsedSec = ((int)time - elapsedMin * 60) % 60;
        ZombieCount.text = zombiesdata.ToString();

        TimeCountMin.text = elapsedMin.ToString();
        TimeCountSec.text = elapsedMin.ToString();
        gameEndUI.SetActive(true);
    }


    IEnumerator ReloadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
