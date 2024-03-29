using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    private Vector3 targetPosition = new Vector3(539f, 336f, -10f);

    // Update is called once per frame
    void Update()
    {
        // Set the camera's position to the desired target position
        transform.position = targetPosition;
    }
}
