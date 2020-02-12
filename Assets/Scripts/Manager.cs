﻿using UnityEngine;
using UnityEngine.Serialization;


public class Manager : MonoBehaviour
{
    private static Manager _instance;
    public static Manager instance
    {
        get
        {
            if (!_instance)
                _instance = new Manager();
            return _instance;
        }
        private set { }
    }

    private static bool _alarm;
    public static bool alarm
    {
        get { return _alarm; }
        set
        {
            _alarm = value;
            _instance.SetAlarm(_alarm);
        }
    }
    
    public AudioSource speaker; // GameObject should have 3 AudioSources, 2 BGMs and a VO. Attached to Player Object
    private AudioSource[] tracks;

    [SerializeField] private float crossfadeLength;
    private float crossfadeTimer;
    private bool crossfading;

    [Range(0, 100)] 
    public float bgmVolume;
    [Range(0, 100)] 
    public float voVolume;
    [Range(0, 100)] 
    public float sfxVolume;

    public AudioClip bgmHi;
    public AudioClip bgmLo;
    public AudioClip voStart;
    public AudioClip voHeist;

    private void Awake()
    {
        if (_instance != null)
            Destroy(this);
        
        tracks = speaker.gameObject.GetComponents<AudioSource>();
        
        if (tracks.Length < 3)
        {
            speaker.gameObject.AddComponent<AudioSource>();
            speaker.gameObject.AddComponent<AudioSource>();
            tracks = speaker.gameObject.GetComponents<AudioSource>();
        }
        
        // Set BGM Tracks
        tracks[0].clip = bgmLo;
        tracks[0].volume = bgmVolume / 100;
        tracks[0].loop = true;
        
        tracks[1].clip = bgmHi;
        tracks[1].volume = 0;
        tracks[1].loop = true;
        
        tracks[2].clip = voStart;
        tracks[2].volume = voVolume / 100;
        tracks[2].loop = false;
    }

    private void Start()
    {
        tracks[0].Play();
        tracks[1].Play();
        tracks[2].Play();
        
        Analytics.StartTrial();
    }

    private void Update()
    {
        if (crossfading)
        {
            crossfadeTimer -= Time.deltaTime;
            if (crossfadeTimer > 0)
            {
                tracks[0].volume = bgmVolume * (crossfadeTimer / crossfadeLength);
                tracks[1].volume = bgmVolume * (1 - crossfadeTimer / crossfadeLength);
            }
            else
            {
                tracks[0].volume = 0;
                tracks[1].volume = 1;
            }
            
        }
    }
    
    private void SetAlarm(bool alarmState)
    {
        crossfadeTimer = crossfadeLength;
        crossfading = true;

        tracks[2].clip = voHeist;
        tracks[2].Play();
    }
}
