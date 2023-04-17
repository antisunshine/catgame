using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int PointsCollected = 0;
    public TextMeshProUGUI PointsOutput;

    void Update()
    {
        PointsOutput.text = "Score: " + PointsCollected;
    }

    public void CollectPoint()
    {
        PointsCollected++;
    }

    public void LosePoint()
    {
        PointsCollected--;
    }

}
