using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;


namespace GameLibs.MemorySystem
{
  public class MemorySystem
  {
    public static void NewGame(string gameName)
    {
      string path = CombinePath(gameName);

      Debug.Log(path);
      BinaryFormatter bf = new BinaryFormatter();
      FileStream file = File.Create(path);
      bf.Serialize(file, new GameData(gameName, 1));
      file.Close();
    }

    public static void SaveGame(GameData gameData)
    {
      string path = CombinePath(gameData.GameName);
      BinaryFormatter bf = new BinaryFormatter();
      FileStream file = File.Create(path);
      bf.Serialize(file, gameData);
      file.Close();
    }

    public static GameData LoadGame(string gameName)
    {
      string path = CombinePath(gameName);

      if(File.Exists(path))
      {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(path, FileMode.Open);
        GameData gameData = (GameData)bf.Deserialize(file);
        file.Close();
        return gameData;
      }

      return null;
    }

    static string CombinePath(string gameName) => Path.Combine(Application.persistentDataPath, gameName + ".data");

    public static FileInfo[] FilePaths => new DirectoryInfo(Application.persistentDataPath + "/").GetFiles("*.data*");
  }
}