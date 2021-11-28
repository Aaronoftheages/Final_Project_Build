using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//tutorial source: https://www.youtube.com/watch?v=XOjd_qU2Ido

public static class SaveSystem {

    public static void SavePlayer (Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.ron";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
       
    }
	
    public static PlayerData LoadPlayer ()
    {
        string path = Application.persistentDataPath + "/player.ron";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            //reads from stream
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
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

