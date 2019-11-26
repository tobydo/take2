using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBoomProto : MonoBehaviour
{
    CharacterController cc;
    public Rigidbody handsRB;

    // as proof of concept, just hardcode the joint instead of sensing with raycast
    public ConfigurableJoint boomHandle;
    Rigidbody boomRB;
    public Vector3 boomOffset = new Vector3(0f, -0.32f, 0.5f);

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // simple player movement
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        transform.Rotate( 0f, h * 360f * Time.deltaTime, 0f);
        cc.Move( transform.forward * v * Time.deltaTime * 10f);

        // pickup objects
        if ( Input.GetKeyDown(KeyCode.E) ) {
            // TODO: raycast / spherecast, sense which boom we are picking up
            boomRB = boomHandle.GetComponent<Rigidbody>();

            // toggle joint's connected body
            // we are holding the boom, so DROP IT...
            if ( boomHandle.connectedBody == handsRB ) {
                boomHandle.connectedBody = null; // disconnect joint

                // snap boom to ground, stabilize boom direction
                var boom = boomHandle.transform;
                boom.position = new Vector3( boom.position.x, 0.25f, boom.position.z);
                boom.eulerAngles = new Vector3( 0f, boom.eulerAngles.y, 0f );

                // turn off physics for the boom
                boomRB.isKinematic = true; 
            } 
            else 
            { // we are not holding the boom, so PICK IT UP
                // reset boom orientation to match player
                boomHandle.transform.position = handsRB.position + transform.TransformDirection(boomOffset);
                boomHandle.transform.forward = handsRB.transform.forward;

                // attach boom to player
                boomHandle.connectedBody = handsRB;
                boomHandle.connectedAnchor = new Vector3(0f, -0.16f, 0.63f);

                // as a precaution, zero-out boom physics... but if boom was already kinematic, there was no physics, so this is maybe unnecessary
                // boomRB.velocity = Vector3.zero;
                // boomRB.angularVelocity = Vector3.zero;

                // turn on physics for the boom again
                boomRB.isKinematic = false;
            }
        }
    }
}
