using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBoomProto : MonoBehaviour
{
    CharacterController cc;
    public Rigidbody handsRB;

    //public PickupRaycast pickupRaycast;
    // as proof of concept, just hardcode the joint instead of sensing with raycast
    public ConfigurableJoint boomHandle;
    Rigidbody boomRB;
    public Vector3 boomOffset = new Vector3(0f, -0.32f, 0.5f);
    public Camera camera;
    public float rayDistance;
    public float distance;

    public GameObject target;
    GameObject itemGrabbed = null;
    bool rbody = false;
    public bool isHeld = false;
    CursorLockMode cursorLock;

    void Start()
    {

        cc = GetComponent<CharacterController>();
        cursorLock = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // simple player movement
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        transform.Rotate(0f, h * 360f * Time.deltaTime, 0f);
        cc.Move(transform.forward * v * Time.deltaTime * 10f);
        if (Input.GetKeyDown("escape"))
        {
            cursorLock = CursorLockMode.None;

        }
        // pickup objects
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (rbody == false)
            {

                Pickup(); // TODO: raycast / spherecast, sense which boom we are picking up

            }

            else
            {
                Drop();
            }

        }
    }
    public void Drop()
    {


        // toggle joint's connected body
        // we are holding the boom, so DROP IT...
        if (boomHandle.connectedBody == handsRB)
        {
            boomHandle.connectedBody = null; // disconnect joint

            // snap boom to ground, stabilize boom direction
            var boom = boomHandle.transform;
            boom.position = new Vector3(boom.position.x, 0.25f, boom.position.z);
            boom.eulerAngles = new Vector3(0f, boom.eulerAngles.y, 0f);

            // turn off physics for the boom
            boomRB.isKinematic = true;
            rbody = false;
            isHeld = false;


            itemGrabbed = null;

        }


    }




   public void Pickup()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.red);
            if (hit.collider != null)
            {


                if (hit.collider.tag == "pickObject")
                {
                    rbody = true;
                    isHeld = true;
                    Debug.Log("You hit a pickObject!");
                    itemGrabbed = hit.collider.gameObject;
                    boomRB = boomHandle.GetComponent<Rigidbody>();



                    itemGrabbed = null;
                    // we are not holding the boom, so PICK IT UP
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
}



