using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngineInternal;

public class CameraEntity : MonoBehaviour
{
    [Tooltip("The key to enter to make the camera scoll down")] [SerializeField] private string keyAxisZoomName = "Mouse ScrollWheel";

    [Tooltip("The speed of zoom of the camera")] [SerializeField] private float cameraZoomSpeed = 1.60f;

    [Tooltip("The MIN field of view of the camera")] [SerializeField] private float minCamFieldView = 0.00f;
    [Tooltip("The MAX field of view of the camera")] [SerializeField] private float maxCamFieldView = 60.00f;

    private float FieldOfView
    {
        get { return GetComponent<Camera>().fieldOfView; }
        set
        {
            if (value >= minCamFieldView && value <= maxCamFieldView)
            {
                GetComponent<Camera>().fieldOfView = value;
            }
        }
    }

    void FixedUpdate()
    {
        if (Input.GetAxis(keyAxisZoomName) > 0)
        {
            FieldOfView -= cameraZoomSpeed;
        }
        else if (Input.GetAxis(keyAxisZoomName) < 0)
        {
            FieldOfView += cameraZoomSpeed;
        }
    }
}
