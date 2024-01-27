using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public PlayerController playerController;
    public Health health;

    [Header("Power up amount")]
    public int whippyCream = 0;

    private void Awake()
    {
        instance = this;
    }
}
