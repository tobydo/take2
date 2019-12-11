using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public GameObject cam;
    public GameObject player;

    public void TurnOff()
    {
        MouseLook mouse = cam.GetComponent<MouseLook>();

        mouse.enabled = false;

        MouseLook playerMouse = player.GetComponent<MouseLook>();

        playerMouse.enabled = false;
    }

    public void TurnOn()
    {
        MouseLook mouse = cam.GetComponent<MouseLook>();

        mouse.enabled = true;

        MouseLook playerMouse = player.GetComponent<MouseLook>();

        playerMouse.enabled = true;

    }

}
