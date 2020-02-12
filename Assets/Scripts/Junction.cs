﻿using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Junction : MonoBehaviour
{
    public Stressor preAlarm;
    public Stressor postAlarm;

    private AudioSource audio;
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
        audio = GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        if (Manager.alarm && !flipped)
        {
            flipped = !flipped;
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

        audio.clip = Manager.alarm ? postAlarm.enterSound.track : preAlarm.enterSound.track;
        audio.volume = ((Manager.alarm ? postAlarm.enterSound.vo : preAlarm.enterSound.vo) 
                           ? Manager.instance.voVolume : Manager.instance.sfxVolume) / 100;
        audio.Play();

        foreach (Exit exit in exits)
        {
            if (Manager.alarm)
                exit.next.OnSight();
            else
                exit.next.OnSight();
        }
    }
    
    // Called when Player.OnTriggerEnter procs on this Junction's Appoach Trigger
    public void OnApproach()
    {
        Analytics.RecordPosition();
        
        audio.clip = Manager.alarm ? postAlarm.approachSound.track : preAlarm.approachSound.track;
        audio.volume = ((Manager.alarm ? postAlarm.approachSound.vo : preAlarm.approachSound.vo) 
                           ? Manager.instance.voVolume : Manager.instance.sfxVolume) / 100;
        audio.Play();
    }

    public void OnSight()
    {
        audio.clip = Manager.alarm ? postAlarm.sightSound.track : preAlarm.sightSound.track;
        audio.volume = ((Manager.alarm ? postAlarm.sightSound.vo : preAlarm.sightSound.vo) 
                           ? Manager.instance.voVolume : Manager.instance.sfxVolume) / 100;
        audio.Play();
    }
}
