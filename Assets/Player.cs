using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public PlayerController playerController;
    public Health health;

    private void Awake()
    {
        instance = this;
    }
}
