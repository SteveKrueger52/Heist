using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject mesh;
    public Vector3 activeLocation;
    public Vector3 hiddenLocation;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //TODO Spacebar [ GetButtonDown("Submit") ] -> Toggle map visibility, seek in/out from bottom and
        //TODO adjust active-ness when fully offscreen.
        
    }

    void GetHoldAngle()
    {
        //TODO make map adjust to vertical camera angle, like in Minecraft.
    } 
}
