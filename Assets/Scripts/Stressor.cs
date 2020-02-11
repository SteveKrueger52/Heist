using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stressor : MonoBehaviour
{
    //TODO dummy class for base Stressor instantiation
    AudioSource[] audios;
    public AudioSource sightSound;
    public AudioSource approachSound;
    public AudioSource enterSound;

    private void Start()
    {
        audios = GetComponents<AudioSource>();
        sightSound = audios[0];
        sightSound = audios[1];
        sightSound = audios[2];
    }

    public void OnSight()
    {
        // play animation when player enters adjacent junction
        sightSound.Play();
    }

    public void OnApproach()
    {
        // play animation when player approaches junction
        approachSound.Play();
    }

    public void OnEnter()
    {
        // play animation when player enters junction
        enterSound.Play();
    }
}
