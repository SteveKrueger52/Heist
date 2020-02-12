using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Stressor", order = 1)]
public class Stressor : ScriptableObject
{
    public struct StressorSound
    {
        public AudioClip track;
        public bool vo; // SFX if not
    }
    public StressorSound sightSound;
    public StressorSound approachSound;
    public StressorSound enterSound;
}