using System;
using UnityEngine;

public class Junction : MonoBehaviour
{

    public Collider approachTrigger;
    public Collider enterTrigger;
    public Stressor preAlarm;
    public Stressor postAlarm;
    public Exit[] exits;
    
    [Serializable]
    public struct Exit
    {
        public float angle;
        public Junction next;
    }

    public void OnAwake()
    {
        /*/ Check Reciprocity - For every junction in exits, this junction must be one of its exits as well.
        foreach (Exit exit in exits)
        {
            if (exit.next.ContainsExit(this))
                Debug.Log("RECIPROCITY FAILED AT " + ToString());
        }
        //*/
        
    }

    public bool ContainsExit(Junction other)
    {
        foreach (Exit exit in exits)
        {
            if (exit.next == other)
                return true;
        }
        return false;
    }
    
    
    
}
