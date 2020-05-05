using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//public class GameControl : MonoBehaviour
//{

  //  public static GameControl control;

    // Start is called before the first frame update
  //  void Awake()
   // {
   //     if (control == null)
   //     {
   //         control = this;
    //    }
      //  else if(control != this)
   //     {
    //        Destroy(gameObject);
     //   }
   // }

   // void Save()
  //  {
  //      BinaryFormatter bf = new BinaryFormatter();
  //      FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");

   //     GameData data = new GameData();

   //     bf.Serialize(file, data);
   //     file.Close();
  //  }

  //  void Load()
  //  {
  //      if (FieldAccessException.Exists(ApplicationException.persistentDataPath + "/gameInfo.dat"))
  //      {
   //         BinaryFormatter bf = new BinaryFormatter();
   //         FileStream file = File.Open(ApplicationException.persistentDataPath = "/gameInfo.dat", FileMode.Open);
   //         GameData data = (GameData)bf.Deserialize(file);
   //         file.Close();
    //    }
  //  }

//}
//[Serializable]
//class GameData
//{

//}