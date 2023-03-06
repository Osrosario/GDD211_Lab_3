using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform camTransform;
    [SerializeField] private CharacterController CC;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float coyoteTime;

    private float camRotation;
    private float verticalSpeed;
    private float originalStepOffset;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        originalStepOffset = CC.stepOffset;
    }

    void Update()
    {
        Camera();
        Movement();
    }

    private void Camera()
    {
        float mouseYInput = Input.GetAxis("Mouse Y") * mouseSensitivity;
        camRotation += -mouseYInput;
        camRotation = Mathf.Clamp(camRotation, -90f, 90f);
        camTransform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0f, 0f));

        float mouseXInput = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, mouseXInput, 0f));
    }

    private void Movement()
    {
        Vector3 movement = Vector3.zero;

        float forwardMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; //Velocity for forward movement
        float sideMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; //Velocity for side movement

        movement += (transform.forward * forwardMovement) + (transform.right * sideMovement); //represents the direction of movement

        if (CC.isGrounded) { lastGroundedTime = Time.time; }
        if (Input.GetKeyDown(KeyCode.Space)) { jumpButtonPressedTime = Time.time; }
        
        if ((Time.time - lastGroundedTime) <= coyoteTime)
        {
            CC.stepOffset = originalStepOffset;

            verticalSpeed = 0f;

            if ((Time.time - jumpButtonPressedTime) <= coyoteTime)
            {
                verticalSpeed = jumpSpeed;
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
            }
        }
        else
        {
            CC.stepOffset = 0;
            verticalSpeed += (gravity * Time.deltaTime);
        }
        
        movement += (transform.up * verticalSpeed * Time.deltaTime);

        CC.Move(movement);
    }
}
