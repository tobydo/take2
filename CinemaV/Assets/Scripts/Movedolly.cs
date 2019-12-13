using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movedolly : MonoBehaviour
{
    
    public float thrust = 1.0f;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    
    
        rb.AddForce(transform.forward * thrust);
    }
}

