/*using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    public static void SaveData (GameManager gm)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.doublea";
        FileStream stream = new FileStream(path, FileMode.Create);

        //GameData data = new GameData(gm);

        formatter.Serialize(stream, data);
        stream.Close();
       
    }
	
    public static GameData LoadData ()
    {
        string path = Application.persistentDataPath + "/save.doublea";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            //reads from stream
            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Not save found in " + path);
            return null;
        }
    }
}
*/
