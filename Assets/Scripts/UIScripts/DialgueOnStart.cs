using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialgueOnStart : MonoBehaviour
{

    public Conversation conversation;


      void Start()
      {
        FindObjectOfType<DialogueManagerNew>().StartConversation(conversation);
    }

}
