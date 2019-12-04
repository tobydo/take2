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
    bool rbody= false;
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
            //Rigidbody rb =itemGrabbed.GetComponent<Rigidbody>();
           // rb.MovePosition(target.transform.position);
       
        }
        if (Input.GetKeyDown(KeyCode.E) )
        {
            if (rbody == false)
            {
                Pickup();
                
            }


            else if (rbody == true)
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

    public void Pickup()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider != null)
            {


                if (hit.collider.tag == "pickObject")
                {
                    rbody = true;
                    isHeld = true;
                    Debug.Log("You hit a pickObject!");
                    itemGrabbed = hit.collider.gameObject;
                 

                }
            }
            
        }

        
    }

    void Drop()
    {
        rbody = false;
        isHeld = false;
    

        itemGrabbed = null;


        }
    }
