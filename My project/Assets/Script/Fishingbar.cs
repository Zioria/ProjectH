using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectH
{
    public class Fishingbar : MonoBehaviour
    {

        public Rigidbody rb;
        public bool atTop;
        public float targetTime;
        public float saveTargetTime;

       // public GameObject Pole;
       // public GameObject Rope;
      //  public GameObject fish1;
       // public GameObject fish2;
    
       // public GameObject Bar1;
       // public GameObject Bar2;
       // public GameObject Bar3;
       // public GameObject Bar4;
       // public GameObject Bar5;
       // public GameObject Bar6;
       // public GameObject Bar7;
       // public GameObject Bar8;

        public bool onFish;
        public Playerfishing playerS;
        public GameObject bobber;

        // Start is called before the first frame update
        void Start()
        {
            //initPos = transform.position;
            //rb.AddForce(Vector3.up, ForceMode.Impulse);
        }

        // Update is called once per frame
        void Update()
        {
            if(onFish == true)
            {
                //targetTime += Time.deltaTime;
                rb.AddForce(Vector3.down, ForceMode.Impulse);
                if(Input.GetKey(KeyCode.T))
                    { 
                        playerS.fishGameWon();
                        rb.AddForce(Vector3.zero, ForceMode.Impulse);
                        transform.localPosition = new Vector3(-0.12613f, 11, -4.65791f);
                        Destroy(GameObject.Find("fish point(Clone)"));
                        Destroy(GameObject.Find("bobber(Clone)"));
                        targetTime = 3.7f;    
                    }
                //onFish = false;
            }

            if(onFish == false)
            {
                targetTime -= Time.deltaTime;
                
                if(Input.GetKey(KeyCode.T))
                {   
                    rb.AddForce(Vector3.zero, ForceMode.Impulse);
                    transform.localPosition = new Vector3(-0.12613f, 11, -4.65791f);
                    Destroy(GameObject.Find("fish point(Clone)"));
                    Destroy(GameObject.Find("bobber(Clone)"));
                    playerS.fishGameLossed();
                    targetTime = 3.7f;
                    return;    
                }
            }
            if(targetTime <= 0.0f)
            {   
                rb.AddForce(Vector3.zero, ForceMode.Impulse); 
                transform.localPosition = new Vector3(-0.12613f, 11, -4.65791f);
                onFish = false;
                playerS.fishGameLossed();
                Destroy(GameObject.Find("bobber(Clone)"));
                Destroy(GameObject.Find("fish point(Clone)"));
                targetTime = 3.7f;
            }
            rb.AddForce(Vector3.up, ForceMode.Impulse);
            if(targetTime == 3.7f)
            {
                //transform.localPosition = new Vector3(-0.12613f, 11, -4.65791f);
                onFish = false;
                   
            }
                //if(Input.GetKey(KeyCode.Space))
           // {
                   // rb.AddForce(Vector3.zero, ForceMode.Impulse);
           // }
            
                
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
