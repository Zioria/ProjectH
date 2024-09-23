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

        public float timetillcatch = 0.0f;
        public bool winneranim;

        // Start is called before the first frame update
        void Start()
        {
            isfishing = false;
            Startfishgame.SetActive(false);
            throwbobber = false;
            targetTime = 0.0f;
            savetargettime = 0.0f;
            extrabobberdistance = 0.0f;

            
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space) && isfishing == false && winneranim == false)
            {
                poleback = true;
                Startfishgame.SetActive(true);
                int randomNumber = Random.Range(0,setPosition.Length);
                GameObject randomPositionObject = setPosition[randomNumber];
                Instantiate(originalfish , randomPositionObject.transform.position, originalfish.transform.rotation);
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
                }
                else
                {
                    extrabobberdistance += targetTime;
                }
            }

            Vector3 temp = new Vector3(extrabobberdistance, 0, 0);
            fishingpoint.transform.position += temp;

           // if(poleback == true)
            //{
                //playeranim.Play("playerSwingBack");
               // savetargettime = targetTime;
              //  targetTime += Time.deltaTime;
           // }

            if(isfishing == true)
            {
                if(throwbobber == true)
                {
                    //Instantiate(bobber, fishingpoint.position, fishingpoint.rotation, transform);
                    fishingpoint.transform.position -= temp;
                    throwbobber = false;
                    targetTime = 0.0f;
                    savetargettime = 0.0f;
                    extrabobberdistance = 0.0f;
                }
                playeranim.Play("playerFishing");
            }

            if(Input.GetKeyDown(KeyCode.P) && timetillcatch <= 0)
            {
                playeranim.Play("Animation_Idle 1");
                Startfishgame.SetActive(false);
                Destroy(GameObject.Find("fish point(Clone)"));
                poleback = false;
                throwbobber = false;
                isfishing = false;
                timetillcatch = 0;
            }
        }

        public void fishGameWon()
        {
            playeranim.Play("playerWonfish");
            Startfishgame.SetActive(false);
            poleback = false;
            throwbobber = false;
            isfishing = false;
            timetillcatch = 0;
        }

        public void fishGameLossed()
        {
            playeranim.Play("Animation_Idle 1");
            Startfishgame.SetActive(false);
            poleback = false;
            throwbobber = false;
            isfishing = false;
            timetillcatch = 0;
        }        
    }
}
