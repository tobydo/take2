using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject cam;
    public GameObject player;

    public void TurnOff()
    {
        MouseLook mouse = cam.GetComponent<MouseLook>();

        mouse.enabled = false;

        MouseLook playerMouse = player.GetComponent<MouseLook>();

        playerMouse.enabled = false;

        CharacterController controler = player.GetComponent<CharacterController>();

        controler.enabled = false;

        FirstPersonDrifter fps = player.GetComponent<FirstPersonDrifter>();

        fps.enabled = false;


    }

    public void TurnOn()
    {
        MouseLook mouse = cam.GetComponent<MouseLook>();

        mouse.enabled = true;

        MouseLook playerMouse = player.GetComponent<MouseLook>();

        playerMouse.enabled = true;

        CharacterController controler = player.GetComponent<CharacterController>();

        controler.enabled = true;

        FirstPersonDrifter fps = player.GetComponent<FirstPersonDrifter>();

        fps.enabled = true;

    }

}
