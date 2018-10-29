using UnityEngine;
using System.Collections;

// This script moves the character controller forward
// and sideways based on the arrow keys.
// It also jumps when pressing space.
// Make sure to attach a character controller to the same game object.
// It is recommended that you make only one call to Move or SimpleMove per frame.

public class Movement : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField]
    Camera cam;
    [SerializeField]
    float camRotationLimit = 85f;
    public float verticalCameraMultiplier = 0.6f;
    private float currentCamRotX = 0;
    public float speed = 6.0f;
    public float mouseSpeed = 6.0f;

    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    Rigidbody rb;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            float xMove = Input.GetAxisRaw("Horizontal");
            float zMove = Input.GetAxisRaw("Vertical");

            
            Vector3 movHorizontal = transform.right * xMove;
            Vector3 movVertical = transform.forward * zMove;



            moveDirection = (movHorizontal + movVertical).normalized * speed;
           

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;
        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        Rotate();
        RotateCam();

    }


    private void Rotate()
    {
        float yRot = Input.GetAxisRaw("Mouse X");
               
        Vector3 rotation = new Vector3(0, yRot, 0) * mouseSpeed;
               
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

         
     
    }
    private void RotateCam()
    {
        float xRot = Input.GetAxisRaw("Mouse Y");
        xRot= (xRot * mouseSpeed) * verticalCameraMultiplier;

        // cam.transform.Rotate(-camRotation);
        currentCamRotX -= xRot;
        currentCamRotX = Mathf.Clamp(currentCamRotX, -camRotationLimit, camRotationLimit);

        cam.transform.localEulerAngles = new Vector3(currentCamRotX, 0, 0);

    }



}
