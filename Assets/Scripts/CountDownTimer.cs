using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    private float currentTime = 0f;
    private float startingTime = 60f;
    private GameManager GM;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;

        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        if(currentTime <= 0)
        {
            currentTime = 0;
        }
        GM.TimeTick(currentTime);
    }

    public void ResetTime()
    {
        currentTime = startingTime;
    }
}
