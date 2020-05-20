using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Conversation
{
    public string name; //speaker's name
    [TextArea(1, 3)] public string[] sentences; //their sentences
}

//[System.Serializable]
//public class Dialogue
//{
 //   public string name;
  //  [TextArea (3, 10)]
  //  public string[] sentences;


//}
