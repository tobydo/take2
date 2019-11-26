using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PickUpObject : MonoBehaviour
{
    public Transform theHand;

    private void OnMouseDown()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = theHand.position;
        this.transform.parent = GameObject.Find("Hand").transform;


    }
    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Collider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
    }

}