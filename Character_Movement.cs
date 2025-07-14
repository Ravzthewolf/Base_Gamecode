using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEditor;
using UnityEngine;




public class Character_Movement : MonoBehaviour
{
    //Speed of player movement
    public float moveSpeed = 5f;

    //Mouse look sensitivity
    public float mouseSensitivity = 100f;

    //Reference to the camera
    public Transform playerCamera;
    
    //Vertical rotation clamp
    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleMouseLook();
    }

    //Handles player movement
    void HandleMovement()
    {
        //Gets movement input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Moves the player on set horizontal or vertical axis
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        //Defines the character base movement speed
        Vector3 movementAmount = movementDirection * moveSpeed * Time.deltaTime;
        
        //Defines movement from character position
        transform.Translate(movementAmount, Space.Self);
    }

    //Handles mouse movement
    void HandleMouseLook()
    {
        //Gets mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Rotate player horizontally
        transform.Rotate(Vector3.up * mouseX);

        //Rotate player vertically
        xRotation -= mouseY;
        
        //Prevent over-rotation
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotates only the camera vertically
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
