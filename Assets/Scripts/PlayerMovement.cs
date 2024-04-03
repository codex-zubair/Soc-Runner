using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float maxSpeed = 14f; // Maximum speed of the car
    public float acceleration = 4f; // Rate of acceleration
    public float deceleration = 2f; // Rate of deceleration
    public float rotationSpeed = 50f; // Rotation speed of the car

    private float currentSpeed = 0f; // Current speed of the car
    private bool isRotatingRight = false; // Flag to indicate if the car is rotating to the right
    private bool isRotatingLeft = false; // Flag to indicate if the car is rotating to the left
    private bool isMovingForward = false; // Flag to indicate if the car is moving forward
    private bool isMovingBackward = false; // Flag to indicate if the car is moving backward

    // Update is called once per frame
    void Update()
    {
        // Rotation input
        float rotateInput = Input.GetAxis("Horizontal");

        // Rotation
        if (currentSpeed != 0f)
        {
            transform.Rotate(Vector3.up * rotateInput * rotationSpeed * Time.deltaTime); // Adjust rotation speed as needed
        }

        // If rotating right flag is true, rotate the car continuously to the right
        if (isRotatingRight)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        // If rotating left flag is true, rotate the car continuously to the left
        if (isRotatingLeft)
        {
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        }

        // Acceleration input
        float accelerateInput = Input.GetAxis("Vertical");

        // Accelerate or decelerate based on input
        if (accelerateInput > 0 || isMovingForward)
        {
            currentSpeed += acceleration * Time.deltaTime;
            isMovingBackward = false; // Set the flag to indicate moving forward
        }
        else if (accelerateInput < 0 || isMovingBackward)
        {
            currentSpeed -= acceleration * Time.deltaTime; // Apply acceleration in reverse for deceleration
            isMovingForward = false; // Set the flag to indicate moving backward
        }
        else
        {
            // Decelerate if no input
            if (currentSpeed > 0)
                currentSpeed -= deceleration * Time.deltaTime; // Apply deceleration if moving forward
            else if (currentSpeed < 0)
                currentSpeed += deceleration * Time.deltaTime; // Apply deceleration if moving backward
        }

        // Clamp speed
        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);

        // Translate the car based on current speed
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        // Reset the flags when speed reaches 0
        if (currentSpeed == 0f)
        {
            isMovingForward = false;
            isMovingBackward = false;
        }
    }

    // Function to handle MoveRight button down event
    public void MoveRightDown()
    {
        // Set the rotating right flag to true
        isRotatingRight = true;
    }

    // Function to handle MoveRight button up event
    public void MoveRightUp()
    {
        // If rotating right, stop the rotation
        isRotatingRight = false;
    }

    // Function to handle MoveLeft button down event
    public void MoveLeftDown()
    {
        // Set the rotating left flag to true
        isRotatingLeft = true;
    }

    // Function to handle MoveLeft button up event
    public void MoveLeftUp()
    {
        // If rotating left, stop the rotation
        isRotatingLeft = false;
    }

    // Function to handle MoveForward button down event
    // Function to handle MoveForward button down event
    public void MoveForwardDown()
    {
    isMovingForward = true;
    }

      public void MoveBackwardDwon()
    {
    isMovingBackward = true;
    isMovingForward = false;
    }

       public void MoveBackwardUp()
    {
    isMovingBackward = false;
    }
    
}
