using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagOfPeanuts : PowerUps.PowerUps
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void SetProperties()
    {
        maxAmount = 30;
    }

    protected override void AddPowerUp()
    {
        // the player is at max hp
        if (Player.instance.health.currentHealth >= Player.instance.health.maxHealth) { return; }
        
        // the full use of power up isn't applied since the hp of player will go over max hp
        if ((Player.instance.health.maxHealth - Player.instance.health.currentHealth) < 30) 
        {
            Player.instance.health.currentHealth = Player.instance.health.maxHealth;
            base.AddPowerUp();
            return;
        };

        // power up is fully used
        Player.instance.health.ChangeHealth(maxAmount);
        base.AddPowerUp();
    }
}
