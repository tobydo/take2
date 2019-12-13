using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public enum CurrentLight
{
    lightOne,
    lightTwo,
    lightThree
}

public class FungusController : MonoBehaviour
{
    public CamBoomProto camboom;
    public Flowchart mainFlowchart;
    public CurrentLight lightCheckpoint = CurrentLight.lightOne;
    public Collider collider;
    public AudioClip ohYeah;
    // Start is called before the first frame update
    void Awake()
    {
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lightCheckpoint != (CurrentLight)mainFlowchart.GetIntegerVariable("light"))
        {

            lightCheckpoint = (CurrentLight)mainFlowchart.GetIntegerVariable("light");

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "BoomHandle")
        {
            switch (lightCheckpoint)
            {
                case CurrentLight.lightOne: mainFlowchart.ExecuteBlock("Light1"); break;
                case CurrentLight.lightTwo: mainFlowchart.ExecuteBlock("Light2"); break;
                case CurrentLight.lightThree: mainFlowchart.ExecuteBlock("Light3"); break;
            }
            other.transform.parent.tag = "Untagged";
            other.tag = "Untagged";
            other.transform.parent.GetChild(0).tag = "Untagged";
            collider.enabled = false;
            AudioSource audioYeah = GetComponent<AudioSource>();
            audioYeah.clip = ohYeah;
            audioYeah.Play();

            CamBoomProto.instance.Drop();
        }
    }
}
