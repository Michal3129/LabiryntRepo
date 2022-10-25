using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;
    private float myAngle;

    private void Update()
    {
        PortalCameraController();
    }
    private void PortalCameraController()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;

        float angularDif = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        if(myAngle == 90 || myAngle == 270)
        {
            angularDif -= 90;

        }
        Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDif, Vector3.up);

        Vector3 newCameraDirection = portalRotationDifference * playerCamera.forward;
        if (myAngle == 90 || myAngle == 270)
        {
            newCameraDirection = new Vector3(newCameraDirection.z * -1, newCameraDirection.y, newCameraDirection.x);
            transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }
        else
        {
            newCameraDirection = new Vector3(newCameraDirection.x * -1, newCameraDirection.y, newCameraDirection.z * -1);
            transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }
    }
}
