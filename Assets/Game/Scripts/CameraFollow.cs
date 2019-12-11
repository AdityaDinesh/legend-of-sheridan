using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform Camera;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(Camera.position, desiredPosition, smoothSpeed);
        Camera.position = smoothedPosition;

        Camera.LookAt(target);
    }
}
