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
            handleCameraZMovement();
        }
    }

    private void handleCameraZMovement()
    {
        //if ((cameraSettings.offset.z >= cameraSettings.minZ) && (cameraSettings.offset.z <= cameraSettings.maxZ))
        //{
        //    transform.position = new Vector3(transform.position.x, transform.position.y, cameraSettings.offset.z);

        //    if (!cameraSettings.invert)
        //    {
        //        cameraSettings.offset.z += scrollValue * cameraSettings.scrollSpeed
        //                            * cameraSettings.scrollMultiplier * Time.deltaTime;
        //    }
        //    else
        //    {
        //        cameraSettings.offset.z += scrollValue * -cameraSettings.scrollSpeed
        //                            * cameraSettings.scrollMultiplier * Time.deltaTime;
        //    }
        //}

        Vector3 position = transform.position;

        if (Input.mousePosition.y >= Screen.height - cameraSettings.panBorderTreshold)
        {
            position.z += cameraSettings.panSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.y <= cameraSettings.panBorderTreshold)
        {
            position.z -= cameraSettings.panSpeed * Time.deltaTime;
        }

        if (transform.position.z < cameraSettings.minZ)
        {
            position = new Vector3(transform.position.x, transform.position.y, cameraSettings.minZ);
        }

        if (transform.position.z > cameraSettings.maxZ)
        {
            position = new Vector3(transform.position.x, transform.position.y, cameraSettings.maxZ);
        }

        transform.position = position;
    }

    private void handleCameraZoom()
    {
        if ((cameraSettings.offset.y < cameraSettings.maxCameraHeight)
            && (cameraSettings.offset.y > cameraSettings.minCameraHeight))
        {
            cameraSettings.offset.y +=
                                    scrollValue * -cameraSettings.scrollSpeed
                                    * cameraSettings.scrollMultiplier * Time.deltaTime;
        }
        else
        {
            if (cameraSettings.offset.y > cameraSettings.maxCameraHeight)
            {
                cameraSettings.offset.y = cameraSettings.maxCameraHeight - 0.5f;
            }
            else if (cameraSettings.offset.y < cameraSettings.minCameraHeight)
            {
                cameraSettings.offset.y = cameraSettings.minCameraHeight + 0.5f;
            }
        }
    }
}