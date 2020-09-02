﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CameraSettings cameraSettings = null;

    [SerializeField] private Transform player = null;

    private Vector3 cameraPosition;

    private void Start()
    {
        cameraSettings = GetComponent<CameraSettings>();
    }

    private void Update()
    {
        transform.position = player.position + cameraSettings.offset;

        transform.LookAt(player);

        handleCameraZoom();
    }

    private void handleCameraZoom()
    {
        float scrollValue = Input.GetAxis("Mouse ScrollWheel");
        cameraSettings.cameraHeight += scrollValue * -cameraSettings.scrollSpeed * cameraSettings.scrollMultiplier * Time.deltaTime;
    }
}
