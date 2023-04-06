using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    Rigidbody playerRb;
    public Transform orientation;

    Vector3 movementDirection;

    float horizontalInput;
    float verticalInput;

    bool isGrounded;

    public float playerHeight;
    public float raycastAddDistance;
    public LayerMask groundMask;
    public float groundDrag;

    // Start is called before the first frame update

   

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.freezeRotation = true;

    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight*0.5f + raycastAddDistance, groundMask);

        KeyboardInput();
        LimitSpeed();

        Debug.Log(isGrounded);

        if (isGrounded)
        {
            playerRb.drag = groundDrag;
        }
        else
        {
            playerRb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void KeyboardInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    public void Movement()
    {
        movementDirection = (orientation.forward * verticalInput) + (orientation.right * horizontalInput);
        playerRb.AddForce(movementDirection.normalized * movementSpeed * 10f, ForceMode.Force);

    }

    private void LimitSpeed()
    {
        Vector3 flatVel = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z);

        if (flatVel.magnitude > movementSpeed)
        {
            Vector3 limitedVelocity = flatVel.normalized * movementSpeed;
            playerRb.velocity = new Vector3(limitedVelocity.x, playerRb.velocity.y, limitedVelocity.z);
        }
    }





    
}
