using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : PowerUps.PowerUps
{
    // Start is called before the first frame update
    void Start()
    {
        SetProperties();
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
        if (PlayerController.instance.currentHealth >= PlayerController.instance.maxHealth) { return; }
        
        // the full use of power up isn't applied since the hp of player will go over max hp
        if ((PlayerController.instance.maxHealth - PlayerController.instance.currentHealth) < 30) 
        {
            //Debug.Log("Power not fully used");
            PlayerController.instance.currentHealth = PlayerController.instance.maxHealth;
            //Debug.Log(PlayerController.instance.currentHealth);
            base.AddPowerUp();
            return;
        };

        // power up is fully used
        //Debug.Log("Power used");
        PlayerController.instance.currentHealth += maxAmount;
        //Debug.Log(PlayerController.instance.currentHealth);
        base.AddPowerUp();
    }
}
