using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using UnityEditorInternal;
using UnityEngine;


public class Analytics : MonoBehaviour
{
    public static Analytics instance;
    
    public float timer;     // Tracks total time in level
    public float timer_in;  // Storage for time to Treasure

    private bool running;
    [HideInInspector] 
    public string log;

    public float logDelay;
    private float logTimer;
    private Player player;
    
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
        {
            timer += Time.deltaTime;
            logTimer += Time.deltaTime;
        }


        if (logTimer > logDelay)
        {
            log += player.transform.position.x + "    " + 
                   player.transform.position.z + "    " + timer + "\n";
            logTimer = 0;
        }
    }

    public static void RecordPosition()
    {
        instance.log += instance.player.transform.position.x + "    " + 
                        instance.player.transform.position.z + "    " + instance.timer + "\n";
        instance.logTimer = 0;
    }

    public static void Reset()
    {
        instance.timer = 0;
        instance.timer_in = 0;
        instance.logTimer = 0;
        instance.running = false;
        instance.log = "";
    }

    public static void StartTrial()
    {
        instance.player = FindObjectOfType<Player>();
        instance.running = true;
        instance.log = "XPos    ZPos    Timestamp\n";
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
