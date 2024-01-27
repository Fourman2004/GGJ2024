using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_stats : MonoBehaviour
{
    public float speed;
    public float health, damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (health)
        {
            case >= 75:
                break;
            case <= 0:
                break;
        }
    }
}
