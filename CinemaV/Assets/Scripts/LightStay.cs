using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightStay : MonoBehaviour
{
    // Vector3 lightPos;
    //Quaternion lightRot;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if (scene.name == "Level4")
        {
            // Destroy the gameobject this script is attached to
            Cursor.visible = true;
            Destroy(gameObject);
        }
    }
}
