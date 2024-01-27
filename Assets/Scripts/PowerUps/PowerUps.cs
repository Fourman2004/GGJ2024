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

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            if(!collisionOccured)
            {
                Debug.Log("Picked up");
                collisionOccured = true;
                CoolDown();
            }
            
        }


        protected abstract void AddPowerUps();

        private void CoolDown()
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            coroutine = HideTimer(5.0f);
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

