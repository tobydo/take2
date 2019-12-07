using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBoomProto : MonoBehaviour
{
    CharacterController cc;
    public Rigidbody handsRB;

    //public PickupRaycast pickupRaycast;
    // as proof of concept, just hardcode the joint instead of sensing with raycast
    public ConfigurableJoint boomHandle1;
    public ConfigurableJoint boomHandle2;
    public ConfigurableJoint boomHandle3;
    Rigidbody boomRB;
    public Vector3 boomOffset = new Vector3(0f, -0.32f, 0.5f);
    public Camera camera;
    public float rayDistance;
    public float distance;
    public Camera rcamera;
    

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
        //// simple player movement
        //var h = Input.GetAxis("Horizontal");
        //var v = Input.GetAxis("Vertical");
        //transform.Rotate(0f, h * 360f * Time.deltaTime, 0f);
        //cc.Move(transform.forward * v * Time.deltaTime * 10f);
        //if (Input.GetKeyDown("escape"))
        //{
        //    cursorLock = CursorLockMode.None;

        //}
      
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
        if (boomHandle1.connectedBody == handsRB)
        {
            boomHandle1.connectedBody = null; // disconnect joint

            // snap boom to ground, stabilize boom direction
            var boom = boomHandle1.transform;
            boom.position = new Vector3(boom.position.x, -.05f, boom.position.z);
            boom.eulerAngles = new Vector3(0f, boom.eulerAngles.y, 0f);

            // turn off physics for the boom
            boomRB.isKinematic = true;
            rbody = false;
            isHeld = false;


            itemGrabbed = null;

        }
        if (boomHandle2.connectedBody == handsRB)
        {
            boomHandle2.connectedBody = null; // disconnect joint

            // snap boom to ground, stabilize boom direction
            var boom = boomHandle2.transform;
            boom.position = new Vector3(boom.position.x, -.05f, boom.position.z);
            boom.eulerAngles = new Vector3(0f, boom.eulerAngles.y, 0f);

            // turn off physics for the boom
            boomRB.isKinematic = true;
            rbody = false;
            isHeld = false;


            itemGrabbed = null;

        }
        if (boomHandle3.connectedBody == handsRB)
        {
            boomHandle3.connectedBody = null; // disconnect joint

            // snap boom to ground, stabilize boom direction
            var boom = boomHandle3.transform;
            boom.position = new Vector3(boom.position.x, -.05f, boom.position.z);
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
        
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);
	Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);

        print("pickup called");

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider != null)
            {
               var localPoint = hit.textureCoord;
                Ray ray2 = rcamera.ScreenPointToRay(new Vector2(localPoint.x * rcamera.pixelWidth, localPoint.y * rcamera.pixelHeight));
                RaycastHit rhit;

                if (Physics.Raycast(ray, out rhit, rayDistance))
                {
                    print(hit.collider.name);

                    if (rhit.collider.tag == "light1")
                    {
                        rbody = true;
                        isHeld = true;
                        Debug.Log("light1");
                        itemGrabbed = rhit.collider.gameObject;
                        boomRB = boomHandle1.GetComponent<Rigidbody>();



                        itemGrabbed = null;
                        // we are not holding the boom, so PICK IT UP
                        // reset boom orientation to match player
                        boomHandle1.transform.position = handsRB.position + transform.TransformDirection(boomOffset);
                        boomHandle1.transform.forward = handsRB.transform.forward;

                        // attach boom to player
                        boomHandle1.connectedBody = handsRB;
                        boomHandle1.connectedAnchor = new Vector3(0f, -0.16f, 0.63f);

                        // as a precaution, zero-out boom physics... but if boom was already kinematic, there was no physics, so this is maybe unnecessary
                        // boomRB.velocity = Vector3.zero;
                        // boomRB.angularVelocity = Vector3.zero;

                        // turn on physics for the boom again
                        boomRB.isKinematic = false;



                    }
                    if (rhit.collider.tag == "light2")
                    {
                        rbody = true;
                        isHeld = true;
                        Debug.Log("light2");
                        itemGrabbed = rhit.collider.gameObject;
                        boomRB = boomHandle2.GetComponent<Rigidbody>();



                        itemGrabbed = null;
                        // we are not holding the boom, so PICK IT UP
                        // reset boom orientation to match player
                        boomHandle2.transform.position = handsRB.position + transform.TransformDirection(boomOffset);
                        boomHandle2.transform.forward = handsRB.transform.forward;

                        // attach boom to player
                        boomHandle2.connectedBody = handsRB;
                        boomHandle2.connectedAnchor = new Vector3(0f, -0.16f, 0.63f);

                        // boomRB.angularVelocity = Vector3.zero;

                        // turn on physics for the boom again
                        boomRB.isKinematic = false;



                    }
                    if (rhit.collider.tag == "light3")
                    {
                        rbody = true;
                        isHeld = true;
                        Debug.Log("light3");
                        itemGrabbed = rhit.collider.gameObject;
                        boomRB = boomHandle3.GetComponent<Rigidbody>();



                        itemGrabbed = null;
                        // we are not holding the boom, so PICK IT UP
                        // reset boom orientation to match player
                        boomHandle3.transform.position = handsRB.position + transform.TransformDirection(boomOffset);
                        boomHandle3.transform.forward = handsRB.transform.forward;

                        // attach boom to player
                        boomHandle3.connectedBody = handsRB;
                        boomHandle3.connectedAnchor = new Vector3(0f, -0.16f, 0.63f);

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
}



