using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectH
{
    public class Playerfishing : MonoBehaviour
    {
        public Animator playeranim;
        public bool isfishing;
        public bool poleback;
        public bool throwbobber;
        public Transform fishingpoint;
        public GameObject bobber;
        public GameObject originalfish;
        public GameObject[] setPosition;

        public float targetTime = 0.0f;
        public float savetargettime;
        public float extrabobberdistance;

        public GameObject Startfishgame;
        public GameObject pointFishbar;
        public float timetillcatch = 0.0f;
        public bool winneranim;
        Vector3 originalPos;

        // Start is called before the first frame update
        void Start()
        {
            isfishing = false;
            Startfishgame.SetActive(false);
            throwbobber = false;
            targetTime = 0.0f;
            savetargettime = 0.0f;
            extrabobberdistance = 0.0f;
            originalPos = new Vector3(-0.12613f, 11, -4.65791f);
            
   
        }

        // Update is called once per frame
        void Update()
        {
            //GameObject.FindGameObjectWithTag("fish");
            if(Input.GetKeyDown(KeyCode.Space) && isfishing == false && winneranim == false)
            {
                
                poleback = true;
                //Startfishgame.SetActive(true);
                //int randomNumber = Random.Range(0,setPosition.Length);
                //GameObject randomPositionObject = setPosition[randomNumber];
                //Instantiate(originalfish , randomPositionObject.transform.position, originalfish.transform.rotation); 
                
            }

            if(isfishing == true)
            {
                timetillcatch += Time.deltaTime;
                if(timetillcatch >= 3)
                {
                        poleback = false;
                        Startfishgame.SetActive(true);
                        //GameObject.FindGameObjectWithTag("fish").SetActive(true);
                        int randomNumber = Random.Range(0,setPosition.Length);
                        GameObject randomPositionObject = setPosition[randomNumber];
                        Instantiate(originalfish , randomPositionObject.transform.position, originalfish.transform.rotation);
                        timetillcatch = -10;
                        
                }

            }
            //if(isfishing == true)
           // {
             //   timetillcatch += Time.deltaTime;
              //  if(timetillcatch >= 2)
              //  {
                //    Startfishgame.SetActive(true);
               
              // }
           // }

           

            if(Input.GetKeyUp(KeyCode.Space) && isfishing == false && winneranim == false)
            {
                poleback = false;
                isfishing = true;
                throwbobber = true;
                if(targetTime >= 0)
                {
                    extrabobberdistance += 0;
                    
                    //int randomNumber = Random.Range(0,setPosition.Length);
                   // GameObject randomPositionObject = setPosition[randomNumber];
                   // Instantiate(originalfish , randomPositionObject.transform.position, originalfish.transform.rotation);
                }
                else
                {
                    extrabobberdistance += targetTime;
                    Destroy(GameObject.Find("fish point(Clone)"));
                }
            }

            Vector3 temp = new Vector3(extrabobberdistance, 0, 0);
            fishingpoint.transform.position += temp;

            if(poleback == true)
            {
                playeranim.Play("playerSwingback");
                savetargettime = targetTime;
                targetTime += Time.deltaTime;
                Destroy(GameObject.Find("fish point(Clone)"));

            }

            if(isfishing == true)
            {
                if(throwbobber == true)
                {
                    //Instantiate(bobber, fishingpoint.position, fishingpoint.rotation, transform);
                    fishingpoint.transform.position -= temp;
                    poleback = false;
                    throwbobber = false;
                    targetTime = 0.0f;
                    savetargettime = 0.0f;
                    extrabobberdistance = 0.0f;
                    //int randomNumber = Random.Range(0,setPosition.Length);
                    //GameObject randomPositionObject = setPosition[randomNumber];
                    //Instantiate(originalfish , randomPositionObject.transform.position, originalfish.transform.rotation);
                    //GameObject.Find("fish point(Clone)").SetActive(false);
                }
                playeranim.Play("playerFishing");
            }

            if(Input.GetKeyDown(KeyCode.P))
            {
                playeranim.Play("Animation_Idle 1");
                Startfishgame.SetActive(false);
                Destroy(GameObject.Find("fish point(Clone)"));
                poleback = false;
                throwbobber = false;
                isfishing = false;
                timetillcatch = 0;
                //pointFishbar.transform.position = originalPos;
            }
        }

        public void fishGameWon()
        {
            playeranim.Play("playerWonfish");
            Destroy(GameObject.Find("fish point(Clone)"));
            Startfishgame.SetActive(false);
            poleback = false;
            throwbobber = false;
            isfishing = false;
            timetillcatch = 0;
        }

        public void fishGameLossed()
        {
            playeranim.Play("playerStill");
            Destroy(GameObject.Find("fish point(Clone)"));
            Startfishgame.SetActive(false);
            poleback = false;
            throwbobber = false;
            isfishing = false;
            timetillcatch = 0;
            //if()
           // {
              //  playeranim.Play("Animation_Idle 1");
           // }
            
        } 



    }
}
