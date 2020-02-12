using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vent : MonoBehaviour
{
    public float range;
    // Update is called once per frame
    void Update()
    {
        Player p = FindObjectOfType<Player>();
        float r = (transform.position - p.transform.position).magnitude;
        if (Manager.alarm && r < range && Input.GetKeyDown(KeyCode.E))
        {
            // End Scene
            // Analytics.EndTrial();
            SceneManager.LoadScene(2);
        }
    }
}
