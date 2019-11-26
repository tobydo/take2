using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchJoints : MonoBehaviour
{
    public Rigidbody handRb;
    public Rigidbody emptyRb;
    public PickupRaycast pickupRaycast;
    public ConfigurableJoint holdJoint;

    bool lastIsHeld;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( pickupRaycast.isHeld == true && lastIsHeld == false)
        {
            holdJoint.connectedBody = handRb;
            transform.position = handRb.transform.position;
            //if it's being held the joint connects to the hand
        }


        if(pickupRaycast.isHeld == false)
        {
            holdJoint.connectedBody = emptyRb;
            //if it's not being held it connects to an empty object

        }
        lastIsHeld = pickupRaycast.isHeld;
    }
}
