using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;
    public TextMeshProUGUI PointsOutput;

    void Awake()
    {
        Instance = this;
    }


    void Update()
    {
        PointsOutput.text = "Score: " + score;
    }


    public void CollectPoint()
    {
        score++;
    }
}
