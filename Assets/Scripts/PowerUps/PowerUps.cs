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
            if(!collisionOccured && other.tag == "Player")
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
            // object mesh isn't visible till timer has finished - will be fully removed when in game object have been updated
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;

            // quick fix to replace mesh component hidden
            if(this.gameObject.transform.GetChild(0))
            {
                this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }

            coroutine = HideTimer(cooldownAmount);
            StartCoroutine(coroutine);
        }

        private IEnumerator HideTimer(float time)
        {
            yield return new WaitForSeconds(time);
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;

            if (this.gameObject.transform.GetChild(0))
            {
                this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }


            collisionOccured = false;
        }
    }
}

