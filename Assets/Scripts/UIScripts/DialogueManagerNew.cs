using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class DialogueManagerNew : MonoBehaviour
{
   
        
        public Conversation[] conversations;
        private Queue<string> sentences;
        private int index = 0; 
        public TextMeshProUGUI nameText, dialogueText;


    //public GameObject levelLoader;
      public int level = 0;


        
        void Start()
        {
            sentences = new Queue<string>();

            
        }

        public void StartConversation(Conversation conversation)
        {

            //animator.SetBool("isOpen", true);

            nameText.text = conversation.name;

            sentences.Clear();

            foreach (string sentence in conversations[index].sentences)
                sentences.Enqueue(sentence);

            DisplayNextSentence();
        }

        public void DisplayNextSentence() //CALL THIS VIA "NEXT" BUTTON
        {
            if (sentences.Count <= 0)
            {
                EndDialogue();
                return;
            }

            string sentence = sentences.Dequeue();
            Debug.Log(sentence);
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }

        private void EndDialogue()
        {
           
            index++;
            if (index < conversations.Length)
            {
                StartConversation(conversations[index]);
                return;
            }
            else
            {
                Debug.Log("End of dialogue.");
            // animator.SetBool("isOpen", false);
            FindObjectOfType<LevelLoader>().LoadLevel(level);


        }
        }

        IEnumerator TypeSentence(string sentence)
        {
            dialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return null;
            }
        }

        public void TriggerDialogue() //CALL THIS VIA BUTTON OR WHATEVER!
        {
            index = 0; //reset the dialogue to its initial sentence
                       //otherwise it will cause a bug
            StartConversation(conversations[index]);
        }
    }




