using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_stats : MonoBehaviour
{
    public float speed, health, SprintMultiplier;
    public int meleeDamage, rangeDamage;
    public GameObject NPC_The_Guy;

    [SerializeField]
    private NPCAnimation NPC;
    [SerializeField]
    private AI_Behaviour Behaviour;

    // Start is called before the first frame update
    void Start()
    {
        NPC = GetComponent<NPCAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (health)
        {
            case 0:
                Destroy(NPC_The_Guy);
                break;
            case >= 75:
                NPC.isWalking = true;
                NPC.isRunning = false;
                break;
            case < 50:
                NPC.isWalking = true;
                NPC.isRunning = true;
                break;
        }
    }
}
