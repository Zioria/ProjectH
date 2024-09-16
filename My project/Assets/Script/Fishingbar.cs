using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectH
{
    public class Fishingbar : MonoBehaviour
    {

        public Rigidbody rb;
        public bool atTop;
        public float targetTime = 4.0f;
        public float saveTargetTime;

        public GameObject Bar1;
        public GameObject Bar2;
        public GameObject Bar3;
        public GameObject Bar4;
        public GameObject Bar5;
        public GameObject Bar6;
        public GameObject Bar7;
        public GameObject Bar8;

        public bool onFish;
        public Playerfishing playerS;
        public GameObject bobber;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if(onFish == true)
            {
                targetTime += Time.deltaTime;
            }
            if(onFish == false)
            {
                targetTime -= Time.deltaTime;
            }

            if(targetTime <= 0.0f)
            {
                transform.localPosition = new Vector3(-0.1224456f, 1, -3.835f);
                onFish = false;
                playerS.fishGameLossed();
                Destroy(GameObject.Find("bobber(Clone)"));
                targetTime = 4.0f;
            }
            if(targetTime >= 8.0f)
            {
                transform.localPosition = new Vector3(-0.1224456f, 1, -3.835f);
                onFish = false;
                playerS.fishGameWon();
                Destroy(GameObject.Find("bobber(Clone)"));
                targetTime = 4.0f;
            }

            if(targetTime >= 0.0f)
            {
                Bar1.SetActive(false);
                Bar2.SetActive(false);
                Bar3.SetActive(false);
                Bar4.SetActive(false);
                Bar5.SetActive(false);
                Bar6.SetActive(false);
                Bar7.SetActive(false);
                Bar8.SetActive(false);
            }
            if(targetTime >= 1.0f)
            {
                Bar1.SetActive(true);
                Bar2.SetActive(false);
                Bar3.SetActive(false);
                Bar4.SetActive(false);
                Bar5.SetActive(false);
                Bar6.SetActive(false);
                Bar7.SetActive(false);
                Bar8.SetActive(false);
            }
            if(targetTime >= 2.0f)
            {
                Bar1.SetActive(true);
                Bar2.SetActive(true);
                Bar3.SetActive(false);
                Bar4.SetActive(false);
                Bar5.SetActive(false);
                Bar6.SetActive(false);
                Bar7.SetActive(false);
                Bar8.SetActive(false);
            }
            if(targetTime >= 3.0f)
            {
                Bar1.SetActive(true);
                Bar2.SetActive(true);
                Bar3.SetActive(true);
                Bar4.SetActive(false);
                Bar5.SetActive(false);
                Bar6.SetActive(false);
                Bar7.SetActive(false);
                Bar8.SetActive(false);
            }
            if(targetTime >= 4.0f)
            {
                Bar1.SetActive(true);
                Bar2.SetActive(true);
                Bar3.SetActive(true);
                Bar4.SetActive(true);
                Bar5.SetActive(false);
                Bar6.SetActive(false);
                Bar7.SetActive(false);
                Bar8.SetActive(false);
            }
            if(targetTime >= 5.0f)
            {
                Bar1.SetActive(true);
                Bar2.SetActive(true);
                Bar3.SetActive(true);
                Bar4.SetActive(true);
                Bar5.SetActive(true);
                Bar6.SetActive(false);
                Bar7.SetActive(false);
                Bar8.SetActive(false);
            }
            if(targetTime >= 6.0f)
            {
                Bar1.SetActive(true);
                Bar2.SetActive(true);
                Bar3.SetActive(true);
                Bar4.SetActive(true);
                Bar5.SetActive(true);
                Bar6.SetActive(true);
                Bar7.SetActive(false);
                Bar8.SetActive(false);
            }
            if(targetTime >= 7.0f)
            {
                Bar1.SetActive(true);
                Bar2.SetActive(true);
                Bar3.SetActive(true);
                Bar4.SetActive(true);
                Bar5.SetActive(true);
                Bar6.SetActive(true);
                Bar7.SetActive(true);
                Bar8.SetActive(false);
            }
            if(targetTime >= 8.0f)
            {
                Bar1.SetActive(true);
                Bar2.SetActive(true);
                Bar3.SetActive(true);
                Bar4.SetActive(true);
                Bar5.SetActive(true);
                Bar6.SetActive(true);
                Bar7.SetActive(true);
                Bar8.SetActive(true);
            }
            if(Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector3.up, ForceMode.Impulse);
            }

        }

        public void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("fish"))
            {
                onFish = true;
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if(other.gameObject.CompareTag("fish"))
            {
                onFish = false;
            }
        }
    }
}
