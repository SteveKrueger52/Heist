using System;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Junction : MonoBehaviour
{
    public Transform preAlarm;
    public Transform postAlarm;
    public Exit[] exits;

    private bool flipped;
    
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
        preAlarm = Instantiate(preAlarm, transform);
        postAlarm = Instantiate(postAlarm, transform);
        
        preAlarm.localPosition = Vector3.zero;
        postAlarm.localPosition = Vector3.zero;
        
        postAlarm.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Manager.alarm && !flipped)
        {
            flipped = !flipped;
            preAlarm.gameObject.SetActive(false);
            postAlarm.gameObject.SetActive(true);
        }
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

    // Called when Player.OnTriggerEnter procs on this Junction's Trigger
    public void OnEnter()
    {
        Analytics.RecordPosition();
        
        if (Manager.alarm)
            postAlarm.GetComponent<Stressor>().OnEnter();
        else
            preAlarm.GetComponent<Stressor>().OnEnter();

        foreach (Exit exit in exits)
        {
            if (Manager.alarm)
                exit.next.postAlarm.GetComponent<Stressor>().OnSight();
            else
                exit.next.preAlarm.GetComponent<Stressor>().OnSight();
        }
    }
    
    // Called when Player.OnTriggerEnter procs on this Junction's Appoach Trigger
    public void OnApproach()
    {
        Analytics.RecordPosition();
        
        if (Manager.alarm)
            postAlarm.GetComponent<Stressor>().OnApproach();
        else
            preAlarm.GetComponent<Stressor>().OnEnter();
    }
}
