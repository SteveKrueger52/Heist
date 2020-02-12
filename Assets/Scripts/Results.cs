using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Results : MonoBehaviour
{
    public Text timeIn;
    public Text timeOut;
    public Text timeTotal;
    
    // Start is called before the first frame update
    void Start()
    {
        timeIn.text = Analytics.instance.timer_in.ToString();
        timeOut.text = (Analytics.instance.timer - Analytics.instance.timer_in).ToString();
        timeOut.text = Analytics.instance.timer.ToString();
    }

    public void Title()
    {
        SceneManager.LoadScene(0);
    }
    // TODO Button Function for Saving Analytics data to file
}
