using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    GameObject[] cameras;
    GameObject camera1;
    GameObject camera2;

    // Start is called before the first frame update
    void Start()
    {
        cameras = GameObject.FindGameObjectsWithTag("MainCamera");
        camera1 = cameras[0];
        camera2 = cameras[1];
        Debug.Log($"cameras.Length:{cameras.Length}");
        Debug.Log($"camera1:{camera1.name}");
        Debug.Log($"camera2:{camera2.name}");
    }

    // Update is called once per frame
    void Update()
    {
        var is1 = Input.GetKey(KeyCode.Alpha1);
        if (is1)
        {
            Debug.Log($"camera1:SetActive");
            var target = camera1;
            foreach (var camera in cameras)
            {
                if(camera!=target)
                {
                    camera.SetActive(false);
                }else
                {
                    target.SetActive(true);
                }
            }
        }
        var is2 = Input.GetKey(KeyCode.Alpha2);
        if (is2)
        {
            Debug.Log($"camera2:SetActive");
            var target = camera2;
            foreach (var camera in cameras)
            {
                if(camera!=target)
                {
                    camera.SetActive(false);
                }else
                {
                    target.SetActive(true);
                }
            }
        }
    }
}
