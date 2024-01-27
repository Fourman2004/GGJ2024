using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public abstract class WeaponController : MonoBehaviour
    {
        public GameObject owner;

        [Header("Shooting based weapons")]
        public Projectile projectilePrefab;
        public Transform shootPoint;
        protected int weaponAmmo;
        public int weaponMagSize;
        protected bool canShootProjectile = true;
        public float shootDelay;
        protected float shootCooldown;
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
            if (canShootProjectile)
            {
                // instantiate projectile
                GameObject spawnedProjectile = Instantiate(projectilePrefab.gameObject, shootPoint.position, shootPoint.rotation);

                // reference the projectile's rigidbody (get component ewww)
                Rigidbody projectileRB = spawnedProjectile.GetComponent<Rigidbody>();

                // add force
                Vector3 projectileForce = owner.transform.forward * throwForce + transform.up * throwUpForce;
                projectileRB.AddForce(projectileForce, ForceMode.Impulse);

                // decreases current ammo
                weaponAmmo--;
                shootCooldown = Time.time + shootDelay;
            }
        }
    }
}

