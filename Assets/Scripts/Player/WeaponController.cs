using System;
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
        public int weaponAmmo;
        public int weaponMagSize;
        protected float shootDelay;
        protected float shootCooldown;
        protected float throwForce;
        protected float throwUpForce;
        public float reloadTime = 5.0f;

        private IEnumerator coroutine;
        protected int ammoToAdd;
        private bool gunReloading = false;
        public int weaponDamage;

        // Start is called before the first frame update
        protected virtual void Start()
        {
            SetProperties();
            weaponAmmo = weaponMagSize;
        }

        // Update is called once per frame
        protected virtual void Update()
        {

        }

        protected abstract void SetProperties();

        protected virtual void Shooting()
        {
            if (weaponAmmo == 0) { return; }

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

        protected virtual void Reload()
        {
            if(gunReloading) { return; }

            Debug.Log("Reload occured");
            coroutine = ReloadTimer(reloadTime);
            StartCoroutine(coroutine);
        }

        protected IEnumerator ReloadTimer(float time)
        {
            Debug.Log("Reloading");
            // so reload can't occur multiple times in one instance
            gunReloading = true;
            yield return new WaitForSeconds(time);

            // allows reload to be either a partial or full mag
            weaponAmmo += ammoToAdd;
            gunReloading = false;
        }

        protected virtual void Melee()
        {

        }
    }
}

