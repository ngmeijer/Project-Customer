﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CameraSettings cameraSettings = null;

    [SerializeField] private Transform player = null;

    [SerializeField] private Vector3 offset;

    private Vector3 cameraPosition;

    private void Start()
    {
        cameraSettings = GetComponent<CameraSettings>();
    }

    private void Update()
    {
        transform.position = player.position + offset;

        transform.LookAt(player);

        handleCameraZoom();

        //transform.position = cameraPosition;
    }

    private void handleCameraZoom()
    {
        float scrollValue = Input.GetAxis("Mouse ScrollWheel");
        offset.y += scrollValue * -cameraSettings.scrollSpeed * cameraSettings.scrollMultiplier * Time.deltaTime;
    }
}
