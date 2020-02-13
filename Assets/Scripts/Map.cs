using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject mesh;
    public Vector3 activeLocation;
    public Vector3 hiddenLocation;
    public float transitionSpeed;

    private bool hidden = true;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = hiddenLocation;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO Spacebar [ GetButtonDown("Submit") ] -> Toggle map visibility, seek in/out from bottom and
        //TODO adjust active-ness when fully offscreen.

        if (Input.GetButtonDown("Submit"))
            hidden = !hidden;
        
        if (hidden && 0 < timer || !hidden & timer < transitionSpeed)
            timer += Time.deltaTime * (hidden ? -1 : 1);
        if (timer < 0)
            timer = 0;
        if (timer > transitionSpeed)
            timer = transitionSpeed;

        transform.localPosition = Vector3.Lerp(hiddenLocation, activeLocation, timer/transitionSpeed);
    }

    void GetHoldAngle()
    {
        //TODO make map adjust to vertical camera angle, like in Minecraft.
    } 
}
