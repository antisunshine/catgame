using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject monsterPrefab1;
    [SerializeField]
    private GameObject monsterPrefab2;
    
    [SerializeField]
    private float monsterInterval1 = 3.5f;
    [SerializeField]
    private float monsterInterval2 = 10f;

    public AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(monsterInterval1, monsterPrefab1));
        StartCoroutine(spawnEnemy(monsterInterval2, monsterPrefab2));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-200f, 200f), Random.Range(-170f, 160f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
