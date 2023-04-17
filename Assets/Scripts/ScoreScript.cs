using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public GameManager GM;

    private void OnTriggerEnter2D(Collider2D TheThingThatWalkedIntoMe)
    {
        if(TheThingThatWalkedIntoMe.name == "Player")
        {
            Debug.Log("You hit a monster");
            GM.CollectPoint();
            Destroy(gameObject);
        }
    }
}
