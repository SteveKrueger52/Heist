using System;
using UnityEngine;

public class Stressor_old : MonoBehaviour
{
    //TODO dummy class for base Stressor instantiation
    AudioSource audioSource;
    
    [Serializable]
    public struct StressorSound
    {
        public AudioClip track;
        public bool vo; // SFX if not
    }
    public StressorSound sightSound;
    public StressorSound approachSound;
    public StressorSound enterSound;
    

    private void OnAwake()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }

    public void OnSight()
    {
        // play animation when player enters adjacent junction
        audioSource.clip = sightSound.track;
        audioSource.volume = (sightSound.vo ? Manager.instance.voVolume : Manager.instance.sfxVolume) / 100;
        audioSource.Play();
    }

    public void OnApproach()
    {
        // play animation when player approaches junction
        audioSource.clip = approachSound.track;
        audioSource.volume = (approachSound.vo ? Manager.instance.voVolume : Manager.instance.sfxVolume) / 100;
        audioSource.Play();
    }

    public void OnEnter()
    {
        // play animation when player enters junction
        audioSource.clip = enterSound.track;
        audioSource.volume = (enterSound.vo ? Manager.instance.voVolume : Manager.instance.sfxVolume) / 100;
        audioSource.Play();
    }
}
