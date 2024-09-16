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

        public float targetTime;
        public float savetargettime;
        public float extrabobberdistance;

        public GameObject Startfishgame;

        public float timetillcatch;
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
            }
            if(isfishing == true)
            {
                timetillcatch += Time.deltaTime;
                if(timetillcatch >= 3)
                {
                    Startfishgame.SetActive(true);
                }
            }

            if(Input.GetKeyUp(KeyCode.Space) && isfishing == false && winneranim == false)
            {
                poleback = false;
                isfishing = true;
                throwbobber = true;
                if(targetTime >= 3)
                {
                    extrabobberdistance += 3;
                }
                else
                {
                    extrabobberdistance += targetTime;
                }
            }

            Vector3 temp = new Vector3(extrabobberdistance, 0, 0);
            fishingpoint.transform.position += temp;

            if(poleback == true)
            {
                playeranim.Play("playerSwingBack");
                savetargettime = targetTime;
                targetTime += Time.deltaTime;
            }

            if(isfishing == true)
            {
                if(throwbobber == true)
                {
                    Instantiate(bobber, fishingpoint.position, fishingpoint.rotation, transform);
                    fishingpoint.transform.position -= temp;
                    throwbobber = false;
                    targetTime = 0.0f;
                    savetargettime = 0.0f;
                    extrabobberdistance = 0.0f;
                }
                playeranim.Play("playerFishing");
            }

            if(Input.GetKeyDown(KeyCode.P) && timetillcatch <= 3)
            {
                playeranim.Play("plaerStill");
                poleback = false;
                throwbobber = false;
                isfishing = false;
                timetillcatch = 0;
            }
        }

        public void fishGameWon()
        {
            playeranim.Play("playerWonfish");
            Startfishgame.SetActive(Startfishgame);
            poleback = false;
            throwbobber = false;
            isfishing = false;
            timetillcatch = 0;
        }

        public void fishGameLossed()
        {
            playeranim.Play("playerStill");
            Startfishgame.SetActive(Startfishgame);
            poleback = false;
            throwbobber = false;
            isfishing = false;
            timetillcatch = 0;
        }        
    }
}
