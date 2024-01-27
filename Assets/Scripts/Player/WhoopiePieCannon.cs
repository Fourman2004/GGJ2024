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

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (PlayerController.instance.input.Player.Fire.WasPressedThisFrame() && Time.time > shootCooldown)
        {
            Shooting();
        }
    }

    protected override void Reload()
    {
        if (PlayerController.instance.input.Player.Reload.WasPressedThisFrame())
        {

        }
    }

    public override void Shooting()
    {
        base.Shooting();
    }
}
