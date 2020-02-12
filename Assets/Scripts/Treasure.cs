using UnityEngine;

public class Treasure : MonoBehaviour
{
    public float range;
    public Transform hand;
    public Vector3 handPos;
    public Vector3 handRot;

    // Update is called once per frame
    void Update()
    {
        Player p = FindObjectOfType<Player>();
        float r = (transform.position - p.transform.position).magnitude;
        
        if (!Manager.alarm && r < range && Input.GetKeyDown(KeyCode.E))
        {
            // Grab Briefcase
            // Analytics.StoreMidpoint();
            Manager.SetAlarm();
            
            transform.SetParent(hand);
            transform.localPosition = handPos;
            transform.localRotation = Quaternion.Euler(handRot);
        }
    }
}
