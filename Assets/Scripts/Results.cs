using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Results : MonoBehaviour
{
    public Text timeIn;
    public Text timeOut;
    public Text timeTotal;
    public Text filename;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        timeIn.text = Mathf.Round(Analytics.timer_in) + " sec";
        timeOut.text = Mathf.Round(Analytics.timer - Analytics.timer_in) + " sec";
        timeTotal.text = Mathf.Round(Analytics.timer) + " sec";
    }

    public void Title()
    {
        SceneManager.LoadScene(0);
    }

    public void WriteFile()
    {
        string file = Analytics.log;
        string dir = Application.persistentDataPath + "/Logs";
        string path =  dir + "/" + filename + ".txt";

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        int increment = 0;
        while (File.Exists(path))
        {
            path = dir + "/" + filename + "_" + increment + ".txt";
        }

        StreamWriter writer = File.CreateText(path);
        writer.Write(file);
        writer.Close();
    }
}
