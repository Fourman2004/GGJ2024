using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WhoopiePieCannon : Weapons.WeaponController
{
     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance.input.Player.Fire.WasPressedThisFrame() && Time.time > shootCooldown)
        {
            Shooting();
        }
    }

    protected override void Reload()
    {

    }

    public override void Shooting()
    {
        base.Shooting();
    }
}
