using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public float time = 60;
    public TextMeshProUGUI PointsOutput;
    public TextMeshProUGUI TimerOutput;

    public GameObject GameOverScreen;

    void Awake()
    {
        Instance = this;
        GameOverScreen.SetActive(false);
    }


    void Update()
    {
        PointsOutput.text = "Score: " + score;
        if(time <= 0)
        {
            GameOverScreen.SetActive(true);
        }
    }


    public void CollectPoint()
    {
        score++;
    }

    public void TimeTick(float timerTime)
    {
        time -= 1 * Time.deltaTime;
        TimerOutput.text = timerTime.ToString("f0");
    }

    public void ResetUI()
    {
        score = 0;
        time = 0;
        GameOverScreen.SetActive(false);
    }
}
