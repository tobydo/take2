using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCamera : MonoBehaviour
{
    public Camera camOne;
    public Camera camTwo;
    public PickupRaycast pickupRaycast;
    bool lastIsHeld;
    // Start is called before the first frame update
    void Start()
    {
        camOne.enabled = true;
        camTwo.enabled = false;
        Debug.Log(camTwo.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (pickupRaycast.isHeld == true && lastIsHeld == false)
        {
            camOne.enabled = false;
            camTwo.enabled = true;

        }
        if(pickupRaycast.isHeld == false)
        {
            camOne.enabled = true;
            camTwo.enabled = false;
        }
        lastIsHeld = pickupRaycast.isHeld;
    }
   

    
}
