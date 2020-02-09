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
    
}
