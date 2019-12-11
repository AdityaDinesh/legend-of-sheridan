using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCameraFollow : MonoBehaviour
{
    public GameObject Camera;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            Camera.GetComponent<CameraFollow>().offset.z = -6f;
            Camera.GetComponent<CameraFollow>().offset.y = 3.5f;
        }
    }
}
