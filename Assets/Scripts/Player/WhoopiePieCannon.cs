using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WhoopiePieCannon : Weapons.WeaponController
{
    public static WhoopiePieCannon instance;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if (instance == null) instance = this;
        else
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this);
    }

    protected override void SetProperties()
    {
        weaponMagSize = 3;
        shootDelay = 0.7f;
        throwForce = 20;
        throwUpForce = 3;
        weaponDamage = 30;
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
        if(Player.instance.whippyCream == 0) { return; }

        if(Player.instance.whippyCream <= 3)
        {
            ammoToChange = Player.instance.whippyCream;
            base.Reload();
            Player.instance.whippyCream -= ammoToChange;
            StartCoroutine(ReloadBar.instance.ShowReload(reloadTime));
        }
        

    }



}
