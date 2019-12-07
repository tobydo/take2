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
    // Start is called before the first frame update
    void Start()
    {
        
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
            other.tag = null;
        }
    }
}
