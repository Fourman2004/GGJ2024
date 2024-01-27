using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WhoopiePieCannon : Weapons.WeaponController
{

    private IEnumerator coroutine;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
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
            coroutine = ReloadTimer(5.0f); ;
            StartCoroutine(coroutine);
        }
    }

}
