using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ManageData
{
    public static void SavePlayerData(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter(); 
        string playerPath = Application.persistentDataPath + "/player.fun";
        FileStream fileStream = new FileStream(playerPath, FileMode.Create);

        PlayerData playerData = new PlayerData(player);

        formatter.Serialize(fileStream, playerData);
        fileStream.Close();
    }

    public static PlayerData LoadPlayerData()
    {
        string playerPath = Application.persistentDataPath + "/player.fun";
        if (File.Exists(playerPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(playerPath, FileMode.Open);

            PlayerData playerData = formatter.Deserialize(fileStream) as PlayerData;
            fileStream.Close();

            return playerData;
        }
        else
        {
            Debug.LogError("No such file!");
            return null;
        }
    }

}
