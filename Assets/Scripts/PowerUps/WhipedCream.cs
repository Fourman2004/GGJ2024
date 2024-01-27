using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipedCream : PowerUps.PowerUps
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_STANDALONE_WIN
        if (Input.GetKeyDown("m"))
        {
            Debug.Log("Max Whoopie Pies Set");
            PlayerController.instance.whippyCream = maxAmount;

        }

#endif
    }

    protected override void SetProperties()
    {
        maxAmount = 6;
        cooldownAmount = 5;
    }

    protected override void AddPowerUp()
    {
        if (maxAmount == PlayerController.instance.whippyCream) { return; };
        Debug.Log("Picked up whippy cream");
        PlayerController.instance.whippyCream++;
        base.AddPowerUp();
    }
}
