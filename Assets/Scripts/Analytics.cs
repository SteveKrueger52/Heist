using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;


public class Analytics : MonoBehaviour
{
    public static Analytics instance;
    
    public float timer;     // Tracks total time in level
    public float timer_in;  // Storage for time to Treasure

    private bool running;
    
    // TODO Whatever Data Type Positional Data should be stored in
    
    void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (running)
            timer += Time.deltaTime;
        
        //TODO Track Positional Data
    }

    public static void Reset()
    {
        instance.timer = 0;
        instance.timer_in = 0;
        instance.running = false;
        
        //TODO Clear Positional Data
    }

    public static void StartTrial()
    {
        instance.running = true;
    }

    public static void StoreMidpoint()
    {
        instance.timer_in = instance.timer;
    }
    
    public static void EndTrial()
    {
        instance.running = false;
    }
}
