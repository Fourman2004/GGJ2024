using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PowerUps
{
    public abstract class PowerUps : MonoBehaviour
    {
        public bool collisionOccured = false;
        private IEnumerator coroutine;
        protected int maxAmount;
        protected float cooldownAmount = 5.0f;

        // Start is called before the first frame update
        public virtual void Start()
        {
            SetProperties();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if(!collisionOccured)
            {
                AddPowerUp();
            }
            
        }


        protected abstract void SetProperties();

        protected virtual void AddPowerUp()
        {
            collisionOccured = true;
            CoolDown();
        }

        protected void CoolDown()
        {
            // object mesh isn't visible till timer has finished
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            coroutine = HideTimer(cooldownAmount);
            StartCoroutine(coroutine);
        }

        private IEnumerator HideTimer(float time)
        {
            yield return new WaitForSeconds(time);
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            collisionOccured = false;
        }
    }
}

