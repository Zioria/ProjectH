using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ProjectH
{
    public class DialogueManager : MonoBehaviour
    {
        public NPC npc;

        bool isTalking;

        float curResponseTrack = 0;
        
        public GameObject dialogueUI;

        public Text npcName;
        public Text npcDialogueBox;
        public Text playerReponse;
        public Image npcImage;



        // Start is called before the first frame update
        void Start()
        {
            dialogueUI.SetActive(false);

        }


        public void OnClickTalk()
        {
            curResponseTrack = 0;

            if (isTalking == false)
            {
                StartConversation();
               
            }
            else if (isTalking == true)
            {
                EndDialogue();
               
            }

          


        }

        public void OnClickRep()
        {
            curResponseTrack++;
            Debug.Log(curResponseTrack);
            
            if(curResponseTrack == 0 )
            {
                playerReponse.text = npc.playerDialogue[1];
                npcDialogueBox.text = npc.dialogue[1];
            }
            
            if (curResponseTrack == 1 && npc.playerDialogue.Length >= 0)
            {
                playerReponse.text = npc.playerDialogue[1];
                npcDialogueBox.text = npc.dialogue[1];
                if (npc.playerDialogue.Length == 1 && npc.dialogue.Length ==2)
                {
                    npcDialogueBox.text = npc.dialogue[2];
                }
            }

           

        }


        void StartConversation()
        {
            isTalking = true;
            dialogueUI.SetActive(true);
            npcName.text = npc.name;
            npcDialogueBox.text = npc.dialogue[0];
            playerReponse.text = npc.playerDialogue[0];
            npcImage.sprite = npc.sprite;
            
        }

        void EndDialogue()
        {
            isTalking = false;
            dialogueUI.SetActive(false);
            
        }
    }
}
