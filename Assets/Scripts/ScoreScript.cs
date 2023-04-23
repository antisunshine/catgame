using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private GameManager GM;
    public AudioSource AS;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        AS = GameObject.Find("Player").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D TheThingThatWalkedIntoMe)
    {

        if (TheThingThatWalkedIntoMe.name == "Player")
        {
            Debug.Log("You hit a monster");
            GM.CollectPoint();
            AS.Play();
            Destroy(gameObject);
        }
    }
}
