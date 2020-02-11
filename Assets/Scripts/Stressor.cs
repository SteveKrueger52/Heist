using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Stressor : MonoBehaviour
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
    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnSight()
    {
        // play animation when player enters adjacent junction
        audioSource.clip = sightSound.track;
        audioSource.volume = (sightSound.vo ? GameManager.voVolume : GameManager.sfxVolume) / 100;
        audioSource.Play();
    }

    public void OnApproach()
    {
        // play animation when player approaches junction
        audioSource.clip = approachSound.track;
        audioSource.volume = (approachSound.vo ? GameManager.voVolume : GameManager.sfxVolume) / 100;
        audioSource.Play();
    }

    public void OnEnter()
    {
        // play animation when player enters junction
        audioSource.clip = enterSound.track;
        audioSource.volume = (enterSound.vo ? GameManager.voVolume : GameManager.sfxVolume) / 100;
        audioSource.Play();
    }
}
