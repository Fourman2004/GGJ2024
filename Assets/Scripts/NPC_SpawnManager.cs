using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject bossSpawnPoint;
    public int basicNpcAmount;
    public bool boss1Spawned;
    public bool boss2Spawned;
    public bool boss3Spawned;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RandomSpawn()
    { 
    
    }

    private void SpawnNPC()
    {

    }

    private void SpawnBoss()
    {
        if(!boss1Spawned)
        {
            boss1Spawned = true;
        }

        if(!boss2Spawned)
        {
            boss2Spawned = true;
        }

        if(!boss3Spawned)
        {
            boss3Spawned = true;
        }
    }
}
