using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStay : MonoBehaviour
{
    // Start is called before the first frame update
    

    private void OnTriggerEnter(Collider other)
    {
        Transform lightPos = other.GetComponent<Transform>();

        DontDestroyOnLoad(lightPos);
    }
}
