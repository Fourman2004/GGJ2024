using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public abstract class WeaponController : MonoBehaviour
    {
        public GameObject owner;

        [Header("Shooting based weapons")]
        protected Projectile projectilePrefab;
        protected GameObject spawnedProjectile;
        protected Transform shootPoint;
        protected int weaponAmmo;
        protected int weaponMagSize;
        protected bool canShootProjectile = true;
        public float throwCooldown;
        public float throwForce;
        public float throwUpForce;

        // Start is called before the first frame update
        void Start()
        {
            weaponAmmo = weaponMagSize;
        }

        // Update is called once per frame
        void Update()
        {

        }

        protected virtual void Reload()
        {
            weaponAmmo = weaponMagSize;
            // want a timer here

            canShootProjectile = true;
        }

        public virtual void Shooting()
        {
            // instantiate projectile
            spawnedProjectile = Instantiate(projectilePrefab.gameObject, shootPoint);

            // reference the projectile's rigidbody (get component ewww)
            Rigidbody projectileRB = spawnedProjectile.GetComponent<Rigidbody>();

            // add force
            Vector3 projectileForce = owner.transform.forward * throwForce + transform.up * throwUpForce;
            projectileRB.AddForce(projectileForce, ForceMode.Impulse);
            // decreases current ammo
            weaponAmmo--;


        }
    }
}

