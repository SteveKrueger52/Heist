using UnityEngine;


public class Analytics : MonoBehaviour
{
    public static Analytics instance;
    
    public static float timer;     // Tracks total time in level
    public static float timer_in;  // Storage for time to Treasure

    private static bool running;
    [HideInInspector] 
    public static string log;

    public static float logDelay = 1;
    private static float logTimer;
    private static Player player;
    
    // TODO Whatever Data Type Positional Data should be stored in
    
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (!(player != null))
            running = false;
        
        if (running)
        {
            timer += Time.deltaTime;
            logTimer += Time.deltaTime;
            if (logTimer > logDelay)
            {
                string temp = player.transform.position.x + "    " + 
                              player.transform.position.z + "    " + timer + "\n";
                //Debug.Log(temp);
                log += temp;
                logTimer = 0;
            }
        }
    }

    public static void RecordPosition()
    {
        string temp = player.transform.position.x + "    " + 
                        player.transform.position.z + "    " + timer + "\n";
        logTimer = 0;
        //Debug.Log(temp);
    }

    public static void Reset()
    {
        timer = 0;
        timer_in = 0;
        logTimer = 0;
        running = false;
        log = "";
    }

    public static void StartTrial()
    {
        player = FindObjectOfType<Player>();
        running = true;
       log = "XPos    ZPos    Timestamp\n";
    }

    public static void StoreMidpoint()
    {
        timer_in = timer;
    }
    
    public static void EndTrial()
    {
        Debug.Log(timer + "    " + timer_in);
        running = false;
        logTimer = 0;
    }
}
