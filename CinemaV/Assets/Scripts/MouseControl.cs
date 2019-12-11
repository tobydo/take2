using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject cam;

    public void TurnOff()
    {
        MouseLook mouse = cam.GetComponent<MouseLook>();

        mouse.enabled = false;

    }

    public void TurnOn()
    {
        MouseLook mouse = cam.GetComponent<MouseLook>();

        mouse.enabled = true;

    }

}
