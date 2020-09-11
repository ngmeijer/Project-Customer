using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CameraSettings cameraSettings = null;
    private float toInvertOrNotToInvert;
    private float scrollValue;
    public float zPosition;

    private void Start()
    {
        cameraSettings = GetComponent<CameraSettings>();

    }

    private void Update()
    {
        scrollValue = Input.GetAxis("Mouse ScrollWheel");

        if (cameraSettings.lockOnPlayer)
        {
            transform.position = cameraSettings.player.position + cameraSettings.offset;
            transform.LookAt(cameraSettings.player);
        }

        if (cameraSettings.abilityToZoom)
        {
            handleCameraZoom();
        }

        if (cameraSettings.moveOnZ)
        {
            handleCameraMovement();
        }
    }

    private void handleCameraMovement()
    {
        Vector3 position = transform.position;

        if (Input.mousePosition.y >= Screen.height - cameraSettings.panBorderTreshold)
        {
            position.z += cameraSettings.panSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.y <= cameraSettings.panBorderTreshold)
        {
            position.z -= cameraSettings.panSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.x >= Screen.width - cameraSettings.panBorderTreshold)
        {
            position.x += cameraSettings.panSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.x <= cameraSettings.panBorderTreshold)
        {
            position.x -= cameraSettings.panSpeed * Time.deltaTime;
        }

        position.x = Mathf.Clamp(position.x, cameraSettings.minBorders.x, cameraSettings.maxBorders.x);
        position.z = Mathf.Clamp(position.z, cameraSettings.minBorders.y, cameraSettings.maxBorders.y);
        position.y = Mathf.Clamp(position.y, cameraSettings.minCameraHeight, cameraSettings.maxCameraHeight);

        position.y += scrollValue * -cameraSettings.scrollSpeed * cameraSettings.scrollMultiplier * Time.deltaTime;

        transform.position = position;
    }

    private void handleCameraZoom()
    {
        if ((cameraSettings.offset.y <= cameraSettings.maxCameraHeight)
            && (cameraSettings.offset.y >= cameraSettings.minCameraHeight))
        {
            cameraSettings.offset.y += scrollValue * -cameraSettings.scrollSpeed
                                    * cameraSettings.scrollMultiplier * Time.deltaTime;
        }
        else if (cameraSettings.offset.y < cameraSettings.minCameraHeight)
        {
            cameraSettings.offset.y = cameraSettings.minCameraHeight + 0.001f;
        }
        else if (cameraSettings.offset.y > cameraSettings.maxCameraHeight)
        {
            cameraSettings.offset.y = cameraSettings.maxCameraHeight - 0.001f;
        }
    }
}