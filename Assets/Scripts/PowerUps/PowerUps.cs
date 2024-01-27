using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PowerUps
{
    public abstract class PowerUps : MonoBehaviour
    {
        public bool collisionOccured = false;
        private IEnumerator coroutine;
        protected int maxAmount;
        protected int currentAmount;
        protected float cooldownAmount = 5.0f;

        // Start is called before the first frame update
        void Start()
        {
            
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
            Debug.Log("Picked up");
            collisionOccured = true;
            CoolDown();
        }

        protected virtual void CoolDown()
        {
            
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

