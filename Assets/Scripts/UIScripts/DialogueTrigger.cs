using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Conversation conversation;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManagerNew>().StartConversation(conversation);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<InGameDialogueManager>().StartConversation(conversation);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<InGameDialogueManager>().EndDialogue();
            Destroy(gameObject);
        }
    }

}
