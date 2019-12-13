using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStay : MonoBehaviour
{
   // Vector3 lightPos;
    //Quaternion lightRot;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void DestroyLight()
    {
        Destroy(this.gameObject);
    }
}
