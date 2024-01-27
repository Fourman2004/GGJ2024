using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 150;
    public int currentHealth = 150;

    [Header("Player HUD Only")]
    public HealthUI healthUI;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = currentHealth;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
    }
}
