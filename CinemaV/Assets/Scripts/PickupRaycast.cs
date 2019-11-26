using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRaycast : MonoBehaviour
{
    public Camera camera;
    public float rayDistance;
    public float distance;

    public GameObject target;
    GameObject itemGrabbed = null;
    bool rbody= true;
    public bool isHeld = false;
    

    CursorLockMode cursorLock;

    void Start()
    {
        cursorLock = CursorLockMode.Locked;
    }

    void Update()
    {
        if(isHeld == true)
        {
            Rigidbody rb =itemGrabbed.GetComponent<Rigidbody>();
            rb.MovePosition(target.transform.position);
       
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (rbody == true)
            {
                Pickup();
                
            }


            else if (rbody == false)
            {
                Drop();
                
            }
        }
        if (Input.GetKeyDown("escape"))
        {
            cursorLock = CursorLockMode.None;

        }
    }
        //End Update

    void Pickup()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider != null)
            {


                if (hit.collider.tag == "pickObject")
                {
                    rbody = false;
                    isHeld = true;
                    Debug.Log("You hit a pickObject!");
                    itemGrabbed = hit.collider.gameObject;
                    itemGrabbed.transform.SetParent(target.transform);
                    //itemGrabbed.transform.localPosition = new Vector3(0, 0, 0);
                    itemGrabbed.GetComponent<Rigidbody>().isKinematic = true;
                    itemGrabbed.GetComponent<Rigidbody>().useGravity = false;

                }
            }
            
        }

        
    }

    void Drop()
    {
        rbody = true;
        isHeld = false;
        Debug.Log(itemGrabbed.name);
        itemGrabbed.GetComponent<Rigidbody>().isKinematic = false;
        itemGrabbed.GetComponent<Rigidbody>().useGravity = true;
        itemGrabbed.transform.SetParent(null);

        itemGrabbed = null;


        }
    }
