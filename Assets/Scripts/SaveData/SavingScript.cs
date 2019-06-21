using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SavingScript : MonoBehaviour
{

    private string savePath;
    
    void Start()
    {
        savePath = Application.persistentDataPath + "/save.cm";
        loadStarsForAllLevels();
        Debug.Log(DataScript.starsForAllLevels[5]);
    }

    
   public void saveStarsForAllLevels()
    {
        var save = new Save()
        {
            starsForAllLevels = DataScript.starsForAllLevels
        };

        var binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(savePath, FileMode.Create);

        binaryFormatter.Serialize(fileStream, save);

        fileStream.Close();
    }

    public void loadStarsForAllLevels()
    {
        if (File.Exists(savePath))
        {
            Save save;

            var binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Open(savePath, FileMode.Open);
            save = binaryFormatter.Deserialize(fileStream) as Save;
            fileStream.Close();

            DataScript.starsForAllLevels = save.starsForAllLevels;

            Debug.Log("Star data loaded");
        }
        else
            Debug.Log("Star data can not be loaded");
    }
}
