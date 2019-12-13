using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class fungusTween : MonoBehaviour
{
    bool plotOut;
    public Flowchart mainFlowchart;

    public void Start()
    {
        plotOut = false;
    }

    // Start is called before the first frame update
    public void Update()
    {

        if ((Input.GetKey(KeyCode.Tab)) && !plotOut)
        {
            mainFlowchart.ExecuteBlock("Tween in");
            plotOut = true;
        }


        if ((Input.GetKey(KeyCode.Tab)) && plotOut)
        {
            mainFlowchart.ExecuteBlock("Tween out");
            plotOut = false;


        }
    }

    
}
