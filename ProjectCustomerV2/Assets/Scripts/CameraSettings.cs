using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    #region Variables

    private Camera cam = null;
    
    [Range(20, 400)]
    public float scrollSpeed = 200f;
    [Range(1, 40)]
    public int scrollMultiplier = 5;

    public Vector3 offset;

    public float cameraHeight = 20;
    public float maxCameraHeight = 50;

    #endregion

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        cam.orthographicSize = cameraHeight;
    }
}