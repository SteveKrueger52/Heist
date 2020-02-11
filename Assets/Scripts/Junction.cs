using System;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Junction : MonoBehaviour
{
    public Stressor preAlarm;
    public Stressor postAlarm;
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
        preAlarm = Instantiate(preAlarm);
        postAlarm = Instantiate(postAlarm);
        
        preAlarm.transform.SetParent(transform);
        postAlarm.transform.SetParent(transform);
        
        preAlarm.transform.localPosition = Vector3.zero;
        postAlarm.transform.localPosition = Vector3.zero;
        
        postAlarm.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.alarm && !flipped)
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
        if (GameManager.alarm)
            postAlarm.OnEnter();
        else
            preAlarm.OnEnter();

        foreach (Exit exit in exits)
        {
            if (GameManager.alarm)
                exit.next.postAlarm.OnSight();
            else
                exit.next.preAlarm.OnSight();
        }
    }
    
    // Called when Player.OnTriggerEnter procs on this Junction's Appoach Trigger
    public void OnApproach()
    {
        if (GameManager.alarm)
            postAlarm.OnApproach();
        else
            preAlarm.OnEnter();
    }
}
