using UnityEngine;

[System.Serializable]
public class AnimCurveSet
{
    public bool HeadBob;
    public bool ItemBob;
    
    [Space(5)]
    [Range(0, 5)] public float headScale;      // How prominent the curves should be
    [Range(0, 5)] public float itemScale;
    [Range(0, 5)] public float loopTime;   // How long the loop should take
    [Range(-1,1)] public float itemDelay;  // How long the delay between head/held items should be
        
    [Space(5)]
    public AnimationCurve x; 
    public AnimationCurve y;
    public AnimationCurve z;

    private float head;

    public Vector3 getHeadOffset(float increment)
    {
        head = head + increment % loopTime;
        if (HeadBob)
            return new Vector3(x.Evaluate(head), y.Evaluate(head), z.Evaluate(head)) * headScale;
        return Vector3.zero;
    }
    
    public Vector3 getItemOffset(float increment)
    {
        head = head + increment % loopTime;
        float tempHead = head + itemDelay % loopTime;
        if (ItemBob)
            return new Vector3(x.Evaluate(tempHead), y.Evaluate(tempHead), z.Evaluate(tempHead)) * itemScale;
        return Vector3.zero;
    }
}