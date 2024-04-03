using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the object the camera should follow
    public Vector3 offset = new Vector3(0f, 7f, 17f); // Adjust offset as needed
    public float followSpeed = 5f; // Adjust follow speed as needed
    public float rotationSpeed = 5f; // Adjust rotation speed as needed

    void LateUpdate()
    {
        // Check if target is assigned
        if (target == null)
            return;

        // Calculate the desired position of the camera
        Vector3 desiredPosition = target.position - target.forward * offset.z + Vector3.up * offset.y;

        // Smoothly move the camera towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * followSpeed);

        // Calculate the desired rotation for the camera
        Quaternion desiredRotation = Quaternion.LookRotation(target.forward, Vector3.up);

        // Smoothly rotate the camera towards the desired rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
    }
}