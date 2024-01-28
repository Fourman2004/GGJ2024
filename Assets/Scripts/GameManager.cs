using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;

    public float spawnDelay = 1f;

    public Transform[] spawnPoints;
    public Transform bossSpawnPoint;
    private bool canSpawn = true;

    public GameObject[] enemies;
    public GameObject boss;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    private void Update()
    {
        
    }
    public void ChangeScore(int amount)
    {
        score += amount;
    }

    public IEnumerator EnemySpawner()
    {
        while (canSpawn)
        {
            yield return new WaitForSeconds(spawnDelay);
            // choose random spawn position
            int randomPosition = Random.Range(0, spawnPoints.Length);

            // choose random enemy to spawn
            int randomEnemy = Random.Range(0, enemies.Length);
            GameObject enemyToSpawn = enemies[randomEnemy];

            Instantiate(enemyToSpawn, spawnPoints[randomPosition].position, spawnPoints[randomPosition].rotation);
        }
    }
}
