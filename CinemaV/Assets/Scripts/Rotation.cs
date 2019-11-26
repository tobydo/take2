using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private Quaternion originalRotation;
    private float startAngle = 0;

    public void Start()
    {
        originalRotation = this.transform.rotation;

    }

    public void InputIsDown()
    {


        originalRotation = this.transform.rotation;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 vector = Input.mousePosition - screenPos;
        startAngle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        //startAngle -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;  // uncomment to pop to where mouse is 


    }

    public void InputIsHeld()
    {

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 vector = Input.mousePosition - screenPos;
        float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        Quaternion newRotation = Quaternion.AngleAxis(angle - startAngle, this.transform.forward);
        newRotation.y = 0; //see comment from above 
        newRotation.eulerAngles = new Vector3(0, 0, newRotation.eulerAngles.z);
        this.transform.rotation = originalRotation * newRotation;



    }
}
