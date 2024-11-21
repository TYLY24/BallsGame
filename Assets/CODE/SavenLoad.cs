using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class SavenLoad : MonoBehaviour
{
     [SerializeField]BallChange ballChange;
    private void Awake()
    {
        //ballChange=GetComponent<BallChange>();
        Load();
    }
    // Start is called before the first frame update
    public void Save()
    {
        Debug.Log("Saved!");
        FileStream file=new FileStream(Application.persistentDataPath+"/Player.dat",FileMode.OpenOrCreate);
        try
        {
            BinaryFormatter formatter=new BinaryFormatter();
            formatter.Serialize(file,ballChange.InfoToSave);
        }
        catch(SerializationException e)
        {
            Debug.LogError("There was an issue in save:"+e.Message);
        }
        finally
        {
            file.Close();
        }
    }

    // Update is called once per frame
    void Load()
    {
        FileStream file= new FileStream(Application.persistentDataPath+"/Player.dat",FileMode.Open);
        try
        {
             BinaryFormatter formatter=new BinaryFormatter();
            ballChange.InfoToSave=(SaveInfo)formatter.Deserialize(file);
            Debug.LogError("Load Success!!!");
        }
        catch(SerializationException e)
        {
            Debug.LogError("There was an issue in Load:"+e.Message);
        }
        finally
        {
            file.Close();
        }
    }
    public void ClearDataPath()
    {
        // Get the path to the persistentDataPath
        string path = Application.persistentDataPath;

        // Check if the directory exists
        if (Directory.Exists(path))
        {
            // Delete all files in the directory
            foreach (string file in Directory.GetFiles(path))
            {
                File.Delete(file);
            }

            // Delete all subdirectories and their files
            foreach (string dir in Directory.GetDirectories(path))
            {
                Directory.Delete(dir, true);
            }

            Debug.Log("All data cleared from persistentDataPath.");
        }
        else
        {
            Debug.LogWarning("persistentDataPath directory does not exist.");
        }
    }
    public void ClearData()
{
    string path = Application.persistentDataPath + "/Player.dat";
    
    if (File.Exists(path))
    {
        File.Delete(path);
        Debug.Log("Data cleared!");
    }
    else
    {
        Debug.LogWarning("No data file found to delete.");
    }
}
}
