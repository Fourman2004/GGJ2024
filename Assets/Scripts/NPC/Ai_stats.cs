using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_stats : MonoBehaviour
{
    public float speed, maxHealth, SprintMultiplier, currentHealth;
    public int meleeDamage, rangeDamage;
    public GameObject NPC_The_Guy;

    [SerializeField]
    private NPCAnimation NPC;
    [SerializeField]
    private AI_Behaviour Behaviour;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        NPC = GetComponent<NPCAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        int percentageOfHealth = Mathf.FloorToInt((currentHealth / maxHealth) * 100);
        switch (percentageOfHealth)
        {
            case 0:
                GameManager.instance.killCount++;
                Destroy(NPC_The_Guy);
                break;
            case >= 100:
                NPC.isWalking = true;
                NPC.isRunning = false;
                break;
            case < 50:
                NPC.isWalking = true;
                NPC.isRunning = true;
                break;
        }
    }

    private void OnDestroy()
    {
        GameManager.instance.ChangeScore(100);
    }
}
