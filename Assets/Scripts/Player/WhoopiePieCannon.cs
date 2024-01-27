using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WhoopiePieCannon : Weapons.WeaponController
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void SetProperties()
    {
        weaponMagSize = 3;
        shootDelay = 0.7f;
        throwForce = 25;
        throwUpForce = 5;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (PlayerController.instance.input.Player.Fire.WasPressedThisFrame() && Time.time > shootCooldown)
        {
            Shooting();
        }

        if (PlayerController.instance.input.Player.Reload.WasPressedThisFrame())
        {
            Reload();
        }
    }

    protected override void Reload()
    {
        if(PlayerController.instance.whippyCream == 0) { return; }

        if(PlayerController.instance.whippyCream <= 3)
        {
            ammoToChange = PlayerController.instance.whippyCream;
            base.Reload();
            PlayerController.instance.whippyCream -= ammoToChange;
        }
        

    }



}
