using UnityEngine;
using UnityEngine.UI;

public class CarController2 : MonoBehaviour
{
    public float maxSpeed = 20f;
    public float acceleration = 5f;
    public float deceleration = 10f;
    private float currentSpeed = 0f;
    private bool isMovingForward = false;
    private bool isMovingBackward = false;
    public Button moveForwardButton;
    public Button moveBackwardButton;

    void Start()
    {
        // Add listeners for button down and button up events
        moveForwardButton.onClick.AddListener(StartMovingForward);
        moveBackwardButton.onClick.AddListener(StartMovingBackward);

        // Add listeners for button up events
        moveForwardButton.onClick.AddListener(StopMovingForward);
        moveBackwardButton.onClick.AddListener(StopMovingBackward);
    }

    void Update()
    {
        float moveInput = GetMoveInput();

        // Update movement based on button states
        if (isMovingForward)
            moveInput = 1f;
        else if (isMovingBackward)
            moveInput = -1f;

        float rotateInput = Input.GetAxis("Horizontal");

        if (moveInput < 0)
            rotateInput *= -1;

        // Adjust speed based on acceleration and deceleration
        currentSpeed += moveInput * (moveInput > 0 ? acceleration : -deceleration) * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);

        // Translate and rotate the car
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * rotateInput * Time.deltaTime * 50);
    }

    // Functions to handle button down events
    public void StartMovingForward()
    {
        isMovingForward = true;
    }

    public void StartMovingBackward()
    {
        isMovingBackward = true;
    }

    // Functions to handle button up events
    public void StopMovingForward()
    {
        isMovingForward = false;
    }

    public void StopMovingBackward()
    {
        isMovingBackward = false;
    }

    // Function to get move input for arrow keys
    float GetMoveInput()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            return 1f;
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            return -1f;
        else
            return 0f;
    }

    private void OnDisable()
    {
        // Remove listeners to prevent memory leaks
        moveForwardButton.onClick.RemoveListener(StartMovingForward);
        moveForwardButton.onClick.RemoveListener(StopMovingForward);
        moveBackwardButton.onClick.RemoveListener(StartMovingBackward);
        moveBackwardButton.onClick.RemoveListener(StopMovingBackward);
    }
}
