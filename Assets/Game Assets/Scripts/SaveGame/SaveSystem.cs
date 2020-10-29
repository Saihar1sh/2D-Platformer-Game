/*using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveGame (PlayerController player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        PlayerData data = new PlayerData(player);
        string path = Application.persistentDataPath + "/savegame.glitch";
        if (File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Append);
            formatter.Serialize(stream, data);
            stream.Close();

        }
        else
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, data);
            stream.Close();

        }

    }

    public static PlayerData LoadGame()
    {
        string path = Application.persistentDataPath + "/savegame.glitch";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save game not found in " + path);
            return null;
        }
    }
}
*/