using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipedCream : PowerUps.PowerUps
{



    // Start is called before the first frame update
    void Start()
    {
        SetProperties();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_STANDALONE_WIN
        if (Input.GetKeyDown("m"))
        {
            Debug.Log("Max Whoopie Pies Set");
            currentAmount = maxAmount;

        }

#endif
    }

    protected override void SetProperties()
    {
        maxAmount = 5;
        cooldownAmount = 5;
    }

    protected override void AddPowerUp()
    {
        if (maxAmount == currentAmount) { return; };
        currentAmount++;
        base.AddPowerUp();
    }
}
