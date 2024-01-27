using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Weapons;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI magsizeText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI whippycreamText;

    public WeaponController weaponREF;

    private void Update()
    {
        magsizeText.text = "Mag Size: " + weaponREF.weaponMagSize.ToString();
        ammoText.text = "Ammo: " + weaponREF.weaponAmmo.ToString();
        whippycreamText.text = "Whippy Cream: " + Player.instance.whippyCream.ToString();
    }
}
