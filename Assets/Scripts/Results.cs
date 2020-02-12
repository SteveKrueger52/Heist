using System.Collections;
using System.Collections.Generic;
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
        
        timeIn.text = Analytics.instance.timer_in.ToString();
        timeOut.text = (Analytics.instance.timer - Analytics.instance.timer_in).ToString();
        timeOut.text = Analytics.instance.timer.ToString();
    }

    public void Title()
    {
        SceneManager.LoadScene(0);
    }

    public void WriteFile()
    {
        string file = Analytics.instance.log;
        string path = "Assets/Resources/Logs/" + filename + ".txt";
        
        StreamWriter writer = new StreamWriter(path, true);
        writer.Write(file);
        writer.Close();
    }
}
