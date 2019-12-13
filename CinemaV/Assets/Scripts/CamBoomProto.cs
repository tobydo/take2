using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBoomProto : MonoBehaviour
{
    public static CamBoomProto instance;
    CharacterController cc;
    public Rigidbody handsRB;

    //public PickupRaycast pickupRaycast;
    // as proof of concept, just hardcode the joint instead of sensing with raycast
    public ConfigurableJoint boomHandle1;
    public ConfigurableJoint boomHandle2;
    public ConfigurableJoint boomHandle3;
    public ConfigurableJoint oscar;
    public ConfigurableJoint table;
    public ConfigurableJoint chair;
    public ConfigurableJoint directorChair;
    public ConfigurableJoint panda;

    public GameObject oscarThing;
    public GameObject tableThing;
    public GameObject chairThing;
    public GameObject directorThing;
    public GameObject pandaThing;

    Rigidbody boomRB;
    public Vector3 boomOffset = new Vector3(0f, -0.32f, 0.5f);
    public Camera camera;
    public float rayDistance;
    public float distance;
    public Camera rcamera;
    public int breakForce;


    public GameObject target;
    GameObject itemGrabbed = null;
    bool rbody = false;
    public bool isHeld = false;
    public bool light = false;
    CursorLockMode cursorLock;
    private void Awake()
    {
        instance = this;
    }
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
                if (light)
                {
                    Drop();
                }
                if (!light)
                {
                    DropNotLight();
                }


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
            light = false;

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
            light = false;

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
			light = false;

			itemGrabbed = null;


			//if (oscar.connectedBody == handsRB)
			//{
			//    oscar.connectedBody = null; // disconnect joint

			//    // snap boom to ground, stabilize boom direction
			//    var boom = boomHandle1.transform;
			//    boom.position = new Vector3(boom.position.x, -.05f, boom.position.z);
			//    boom.eulerAngles = new Vector3(0f, boom.eulerAngles.y, 0f);

			//    // turn off physics for the boom
			//    boomRB.isKinematic = true;
			//    rbody = false;
			//    isHeld = false;
			//    light = false;

			//    itemGrabbed = null;

		}
    }



    public void DropNotLight()
    {


        // toggle joint's connected body
        //we are holding the boom, so DROP IT...
        if (oscar.connectedBody == handsRB)
        {
            oscar.connectedBody = null; // disconnect joint

            // snap boom to ground, stabilize boom direction
            Rigidbody rb = oscar.GetComponent<Rigidbody>();

            Destroy(oscar);

            StartCoroutine("CreateJointOscar");
            //foreach(System.Reflection.FieldInfo field in boomHandle1.GetType().GetFields())
            //{
            //    field.SetValue(oscar, field.GetValue(boomHandle1.GetType()));
            //}

            //rb.AddForce(breakForce, breakForce, breakForce);
        }

        if (table.connectedBody == handsRB)
        {
            table.connectedBody = null; // disconnect joint

            // snap boom to ground, stabilize boom direction
            Rigidbody rb = table.GetComponent<Rigidbody>();

            Destroy(table);

            StartCoroutine("CreateJointTable");
            //foreach(System.Reflection.FieldInfo field in boomHandle1.GetType().GetFields())
            //{
            //    field.SetValue(oscar, field.GetValue(boomHandle1.GetType()));
            //}

            //rb.AddForce(breakForce, breakForce, breakForce);
        }

        if (chair.connectedBody == handsRB)
        {
            chair.connectedBody = null; // disconnect joint

            // snap boom to ground, stabilize boom direction
            Rigidbody rb = chair.GetComponent<Rigidbody>();

            Destroy(chair);

            StartCoroutine("CreateJointChair");
            //foreach(System.Reflection.FieldInfo field in boomHandle1.GetType().GetFields())
            //{
            //    field.SetValue(oscar, field.GetValue(boomHandle1.GetType()));
            //}

            //rb.AddForce(breakForce, breakForce, breakForce);
        }

        if (directorChair.connectedBody == handsRB)
        {
            directorChair.connectedBody = null; // disconnect joint

            // snap boom to ground, stabilize boom direction
            Rigidbody rb = directorChair.GetComponent<Rigidbody>();

            Destroy(directorChair);

            StartCoroutine("CreateJointDirector");
            //foreach(System.Reflection.FieldInfo field in boomHandle1.GetType().GetFields())
            //{
            //    field.SetValue(oscar, field.GetValue(boomHandle1.GetType()));
            //}

            //rb.AddForce(breakForce, breakForce, breakForce);
        }

        if (panda.connectedBody == handsRB)
        {
            panda.connectedBody = null; // disconnect joint

            // snap boom to ground, stabilize boom direction
            Rigidbody rb = panda.GetComponent<Rigidbody>();

            Destroy(panda);

            StartCoroutine("CreateJointPanda");
            //foreach(System.Reflection.FieldInfo field in boomHandle1.GetType().GetFields())
            //{
            //    field.SetValue(oscar, field.GetValue(boomHandle1.GetType()));
            //}

            //rb.AddForce(breakForce, breakForce, breakForce);
        }
        // turn off physics for the booms
        //boomRB.isKinematic = true;
        rbody = false;
            isHeld = false;


            itemGrabbed = null;

        }

        private IEnumerator CreateJointOscar()
        {
        print("new joint made");
            yield return new WaitForSeconds(1f);

            oscar = oscarThing.AddComponent<ConfigurableJoint>() as ConfigurableJoint;

            //oscar.connectedBody = rb;
            oscar.connectedAnchor = boomHandle1.connectedAnchor;
            oscar.angularXLimitSpring = boomHandle1.angularXLimitSpring;
            oscar.anchor = boomHandle1.anchor;
            oscar.angularXDrive = boomHandle1.angularXDrive;
            oscar.angularXMotion = boomHandle1.angularXMotion;
            oscar.angularYLimit = boomHandle1.angularYLimit;
            oscar.angularYMotion = boomHandle1.angularYMotion;
            oscar.angularYZDrive = boomHandle1.angularYZDrive;
            oscar.angularYZLimitSpring = boomHandle1.angularYZLimitSpring;
            oscar.angularZLimit = boomHandle1.angularZLimit;
            oscar.angularZMotion = boomHandle1.angularZMotion;
            oscar.autoConfigureConnectedAnchor = boomHandle1.autoConfigureConnectedAnchor;
            oscar.axis = boomHandle1.axis;
            oscar.breakForce = boomHandle1.breakForce;
            oscar.breakTorque = boomHandle1.breakTorque;
            oscar.connectedAnchor = boomHandle1.connectedAnchor;
            oscar.targetAngularVelocity = boomHandle1.targetAngularVelocity;
            oscar.targetPosition = boomHandle1.targetPosition;
            oscar.targetRotation = boomHandle1.targetRotation;
            oscar.targetVelocity = boomHandle1.targetVelocity;
            oscar.xDrive = boomHandle1.xDrive;
            oscar.xMotion = boomHandle1.xMotion;
            oscar.yDrive = boomHandle1.yDrive;
            oscar.yMotion = boomHandle1.yMotion;
            oscar.zDrive = boomHandle1.zDrive;
            oscar.zMotion = boomHandle1.zMotion;
            oscar.projectionAngle = boomHandle1.projectionAngle;
            oscar.projectionDistance = boomHandle1.projectionDistance;
        }

    private IEnumerator CreateJointTable()
    {
        print("new joint made");
        yield return new WaitForSeconds(1f);

        table = tableThing.AddComponent<ConfigurableJoint>() as ConfigurableJoint;

        //oscar.connectedBody = rb;

        table.connectedAnchor = boomHandle1.connectedAnchor;
        table.angularXLimitSpring = boomHandle1.angularXLimitSpring;
        table.anchor = boomHandle1.anchor;
        table.angularXDrive = boomHandle1.angularXDrive;
        table.angularXMotion = boomHandle1.angularXMotion;
        table.angularYLimit = boomHandle1.angularYLimit;
        table.angularYMotion = boomHandle1.angularYMotion;
        table.angularYZDrive = boomHandle1.angularYZDrive;
        table.angularYZLimitSpring = boomHandle1.angularYZLimitSpring;
        table.angularZLimit = boomHandle1.angularZLimit;
        table.angularZMotion = boomHandle1.angularZMotion;
        table.autoConfigureConnectedAnchor = boomHandle1.autoConfigureConnectedAnchor;
        table.axis = boomHandle1.axis;
        table.breakForce = boomHandle1.breakForce;
        table.breakTorque = boomHandle1.breakTorque;
        table.connectedAnchor = boomHandle1.connectedAnchor;
        table.targetAngularVelocity = boomHandle1.targetAngularVelocity;
        table.targetPosition = boomHandle1.targetPosition;
        table.targetRotation = boomHandle1.targetRotation;
        table.targetVelocity = boomHandle1.targetVelocity;
        table.xDrive = boomHandle1.xDrive;
        table.xMotion = boomHandle1.xMotion;
        table.yDrive = boomHandle1.yDrive;
        table.yMotion = boomHandle1.yMotion;
        table.zDrive = boomHandle1.zDrive;
        table.zMotion = boomHandle1.zMotion;
        table.projectionAngle = boomHandle1.projectionAngle;
        table.projectionDistance = boomHandle1.projectionDistance;
    }

    private IEnumerator CreateJointChair()
    {
        print("new joint made");
        yield return new WaitForSeconds(1f);

        chair = chairThing.AddComponent<ConfigurableJoint>() as ConfigurableJoint;

        //oscar.connectedBody = rb;
        chair.connectedAnchor = boomHandle1.connectedAnchor;
        chair.angularXLimitSpring = boomHandle1.angularXLimitSpring;
        chair.anchor = boomHandle1.anchor;
        chair.angularXDrive = boomHandle1.angularXDrive;
        chair.angularXMotion = boomHandle1.angularXMotion;
        chair.angularYLimit = boomHandle1.angularYLimit;
        chair.angularYMotion = boomHandle1.angularYMotion;
        chair.angularYZDrive = boomHandle1.angularYZDrive;
        chair.angularYZLimitSpring = boomHandle1.angularYZLimitSpring;
        chair.angularZLimit = boomHandle1.angularZLimit;
        chair.angularZMotion = boomHandle1.angularZMotion;
        chair.autoConfigureConnectedAnchor = boomHandle1.autoConfigureConnectedAnchor;
        chair.axis = boomHandle1.axis;
        chair.breakForce = boomHandle1.breakForce;
        chair.breakTorque = boomHandle1.breakTorque;
        chair.connectedAnchor = boomHandle1.connectedAnchor;
        chair.targetAngularVelocity = boomHandle1.targetAngularVelocity;
        chair.targetPosition = boomHandle1.targetPosition;
        chair.targetRotation = boomHandle1.targetRotation;
        chair.targetVelocity = boomHandle1.targetVelocity;
        chair.xDrive = boomHandle1.xDrive;
        chair.xMotion = boomHandle1.xMotion;
        chair.yDrive = boomHandle1.yDrive;
        chair.yMotion = boomHandle1.yMotion;
        chair.zDrive = boomHandle1.zDrive;
        chair.zMotion = boomHandle1.zMotion;
        chair.projectionAngle = boomHandle1.projectionAngle;
        chair.projectionDistance = boomHandle1.projectionDistance;
    }
    private IEnumerator CreateJointDirector()
    {
        print("new joint made");
        yield return new WaitForSeconds(1f);

        directorChair = directorThing.AddComponent<ConfigurableJoint>() as ConfigurableJoint;

        //oscar.connectedBody = rb;
        directorChair.connectedAnchor = boomHandle1.connectedAnchor;
        directorChair.angularXLimitSpring = boomHandle1.angularXLimitSpring;
        directorChair.anchor = boomHandle1.anchor;
        directorChair.angularXDrive = boomHandle1.angularXDrive;
        directorChair.angularXMotion = boomHandle1.angularXMotion;
        directorChair.angularYLimit = boomHandle1.angularYLimit;
        directorChair.angularYMotion = boomHandle1.angularYMotion;
        directorChair.angularYZDrive = boomHandle1.angularYZDrive;
        directorChair.angularYZLimitSpring = boomHandle1.angularYZLimitSpring;
        directorChair.angularZLimit = boomHandle1.angularZLimit;
        directorChair.angularZMotion = boomHandle1.angularZMotion;
        directorChair.autoConfigureConnectedAnchor = boomHandle1.autoConfigureConnectedAnchor;
        directorChair.axis = boomHandle1.axis;
        directorChair.breakForce = boomHandle1.breakForce;
        directorChair.breakTorque = boomHandle1.breakTorque;
        directorChair.connectedAnchor = boomHandle1.connectedAnchor;
        directorChair.targetAngularVelocity = boomHandle1.targetAngularVelocity;
        directorChair.targetPosition = boomHandle1.targetPosition;
        directorChair.targetRotation = boomHandle1.targetRotation;
        directorChair.targetVelocity = boomHandle1.targetVelocity;
        directorChair.xDrive = boomHandle1.xDrive;
        directorChair.xMotion = boomHandle1.xMotion;
        directorChair.yDrive = boomHandle1.yDrive;
        directorChair.yMotion = boomHandle1.yMotion;
        directorChair.zDrive = boomHandle1.zDrive;
        directorChair.zMotion = boomHandle1.zMotion;
        directorChair.projectionAngle = boomHandle1.projectionAngle;
        directorChair.projectionDistance = boomHandle1.projectionDistance;
    }
    private IEnumerator CreateJointPanda()
    {
        print("new joint made");
        yield return new WaitForSeconds(1f);

        panda = pandaThing.AddComponent<ConfigurableJoint>() as ConfigurableJoint;

        //oscar.connectedBody = rb;
        panda.connectedAnchor = boomHandle1.connectedAnchor;
        panda.angularXLimitSpring = boomHandle1.angularXLimitSpring;
        panda.anchor = boomHandle1.anchor;
        panda.angularXDrive = boomHandle1.angularXDrive;
        panda.angularXMotion = boomHandle1.angularXMotion;
        panda.angularYLimit = boomHandle1.angularYLimit;
        panda.angularYMotion = boomHandle1.angularYMotion;
        panda.angularYZDrive = boomHandle1.angularYZDrive;
        panda.angularYZLimitSpring = boomHandle1.angularYZLimitSpring;
        panda.angularZLimit = boomHandle1.angularZLimit;
        panda.angularZMotion = boomHandle1.angularZMotion;
        panda.autoConfigureConnectedAnchor = boomHandle1.autoConfigureConnectedAnchor;
        panda.axis = boomHandle1.axis;
        panda.breakForce = boomHandle1.breakForce;
        panda.breakTorque = boomHandle1.breakTorque;
        panda.connectedAnchor = boomHandle1.connectedAnchor;
        panda.targetAngularVelocity = boomHandle1.targetAngularVelocity;
        panda.targetPosition = boomHandle1.targetPosition;
        panda.targetRotation = boomHandle1.targetRotation;
        panda.targetVelocity = boomHandle1.targetVelocity;
        panda.xDrive = boomHandle1.xDrive;
        panda.xMotion = boomHandle1.xMotion;
        panda.yDrive = boomHandle1.yDrive;
        panda.yMotion = boomHandle1.yMotion;
        panda.zDrive = boomHandle1.zDrive;
        panda.zMotion = boomHandle1.zMotion;
        panda.projectionAngle = boomHandle1.projectionAngle;
        panda.projectionDistance = boomHandle1.projectionDistance;
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
                            light = true;


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
                            light = true;


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
                            light = true;
                        }
                    if (rhit.collider.tag == "oscar")
                    {
                        rbody = true;
                        isHeld = true;
                        Debug.Log("oscar");
                        itemGrabbed = rhit.collider.gameObject;
                        boomRB = oscar.GetComponent<Rigidbody>();



                        itemGrabbed = null;
                        // we are not holding the boom, so PICK IT UP
                        // reset boom orientation to match player
                        oscar.transform.position = handsRB.position + transform.TransformDirection(boomOffset);
                        oscar.transform.forward = handsRB.transform.forward;

                        // attach boom to player
                        oscar.connectedBody = handsRB;
                        oscar.connectedAnchor = new Vector3(0f, -0.16f, 0.63f);

                        // boomRB.angularVelocity = Vector3.zero;

                        // turn on physics for the boom again
                        boomRB.isKinematic = false;
                        


                    }
                    if (rhit.collider.tag == "table")
                    {
                        rbody = true;
                        isHeld = true;
                        Debug.Log("table");
                        itemGrabbed = rhit.collider.gameObject;
                        boomRB = table.GetComponent<Rigidbody>();



                        itemGrabbed = null;
                        // we are not holding the boom, so PICK IT UP
                        // reset boom orientation to match player
                        table.transform.position = handsRB.position + transform.TransformDirection(boomOffset);
                        table.transform.forward = handsRB.transform.forward;

                        // attach boom to player
                        table.connectedBody = handsRB;
                        table.connectedAnchor = new Vector3(0f, -0.16f, 0.63f);

                        // boomRB.angularVelocity = Vector3.zero;

                        // turn on physics for the boom again
                        boomRB.isKinematic = false;



                    }

                    if (rhit.collider.tag == "chair")
                    {
                        rbody = true;
                        isHeld = true;
                        Debug.Log("chair");
                        itemGrabbed = rhit.collider.gameObject;
                        boomRB = chair.GetComponent<Rigidbody>();



                        itemGrabbed = null;
                        // we are not holding the boom, so PICK IT UP
                        // reset boom orientation to match player
                        chair.transform.position = handsRB.position + transform.TransformDirection(boomOffset);
                        chair.transform.forward = handsRB.transform.forward;

                        // attach boom to player
                        chair.connectedBody = handsRB;
                        chair.connectedAnchor = new Vector3(0f, -0.16f, 0.63f);

                        // boomRB.angularVelocity = Vector3.zero;

                        // turn on physics for the boom again
                        boomRB.isKinematic = false;


                    }
                    if (rhit.collider.tag == "director chair")
                    {
                        rbody = true;
                        isHeld = true;
                        Debug.Log("chair");
                        itemGrabbed = rhit.collider.gameObject;
                        boomRB = directorChair.GetComponent<Rigidbody>();



                        itemGrabbed = null;
                        // we are not holding the boom, so PICK IT UP
                        // reset boom orientation to match player
                        directorChair.transform.position = handsRB.position + transform.TransformDirection(boomOffset);
                        directorChair.transform.forward = handsRB.transform.forward;

                        // attach boom to player
                        directorChair.connectedBody = handsRB;
                        directorChair.connectedAnchor = new Vector3(0f, -0.16f, 0.63f);

                        // boomRB.angularVelocity = Vector3.zero;

                        // turn on physics for the boom again
                        boomRB.isKinematic = false;


                    }
                    if (rhit.collider.tag == "panda")
                    {
                        rbody = true;
                        isHeld = true;
                        Debug.Log("panda");
                        itemGrabbed = rhit.collider.gameObject;
                        boomRB = panda.GetComponent<Rigidbody>();



                        itemGrabbed = null;
                        // we are not holding the boom, so PICK IT UP
                        // reset boom orientation to match player
                        panda.transform.position = handsRB.position + transform.TransformDirection(boomOffset);
                        panda.transform.forward = handsRB.transform.forward;

                        // attach boom to player
                        panda.connectedBody = handsRB;
                        panda.connectedAnchor = new Vector3(0f, -0.16f, 0.63f);

                        // boomRB.angularVelocity = Vector3.zero;

                        // turn on physics for the boom again
                        boomRB.isKinematic = false;


                    }
                }
                }
            }
        }
    }




