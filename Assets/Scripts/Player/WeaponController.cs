using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public abstract class WeaponController : MonoBehaviour
    {
        protected int weaponAmmo;
        protected int weaponMagSize; 

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        protected virtual void Reload()
        {
            weaponAmmo = weaponMagSize;
            // want a timer here
        }

        void Shooting()
        {
            // decreases current ammo
        }
    }
}

