using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStay : MonoBehaviour
{
    Transform lightPos;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(lightPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform lightPos = other.GetComponent<Transform>();

       
    }
}
