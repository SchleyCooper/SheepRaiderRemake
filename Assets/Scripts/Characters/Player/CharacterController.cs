using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float turnSpeed = 2.0f;
    public float jumpForce = 10.0f;

    private Rigidbody rb;
    private Camera followCam;

    private Vector3 input;

    private Vector3 movementDirection = Vector3.zero;

    private Vector3 smoothPosition = Vector3.zero;
    private Vector3 targetPosition = Vector3.zero;
    private Quaternion smoothRotation = Quaternion.identity;
    private Quaternion targetRotation = Quaternion.identity;

    private Vector3 velocityRef;

    private bool isGrounded;
    [SerializeField]
    private float groundDistance = 1.0f;
    [SerializeField]
    private LayerMask groundedMask;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        followCam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        smoothPosition = transform.position;
        smoothRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");

        movementDirection = followCam.transform.forward * input.z + followCam.transform.right * input.x;
        movementDirection.y = 0;
        movementDirection.Normalize();

        //targetPosition = transform.position + movementDirection;
        //targetPosition = transform.rotation * movementDirection;
        //targetPosition.y = 0;

        //// rotate
        //if (movementDirection.magnitude > 0.01f)
        //{
        //    targetRotation = Quaternion.LookRotation(movementDirection);
        //}
        //smoothRotation = Quaternion.Slerp(smoothRotation, targetRotation, Time.deltaTime * turnSpeed);
        //transform.rotation = smoothRotation;

        //// move
        //smoothPosition = Vector3.Lerp(smoothPosition, targetPosition, Time.deltaTime * moveSpeed);
        //transform.position = smoothPosition;

        if (Physics.Raycast(transform.position, -transform.up, groundDistance, groundedMask))
        {
            isGrounded = true;
        }
        else
            isGrounded = false;

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        //Debug.DrawRay(followCam.transform.position, followCam.transform.rotation * input.normalized * 3, Color.magenta);
        Debug.DrawRay(transform.position, transform.forward * input.magnitude * 3, Color.red);
        Debug.DrawRay(transform.position, movementDirection * moveSpeed, Color.green);
        //Debug.DrawRay(transform.position, transform.rotation * movementDirection * 2, Color.green);
    }

    private void FixedUpdate()
    {
        targetPosition = rb.position + movementDirection;
        //targetPosition = transform.rotation * movementDirection;
        targetPosition.y = 0;

        // rotate
        if (movementDirection.magnitude > 0.01f)
        {
            targetRotation = Quaternion.LookRotation(movementDirection);
        }
        smoothRotation = Quaternion.Slerp(smoothRotation, targetRotation, Time.fixedDeltaTime * turnSpeed);
        rb.MoveRotation(smoothRotation);

        // move
        smoothPosition = Vector3.Lerp(smoothPosition, targetPosition, Time.fixedDeltaTime * moveSpeed);
        // rb.MovePosition(smoothPosition);
        // rb.velocity = movementDirection.normalized * moveSpeed * Time.fixedDeltaTime;
        // rb.AddForce(movementDirection * moveSpeed);

        // rb.MovePosition(rb.position + movementDirection.normalized * moveSpeed * Time.fixedDeltaTime);
        Vector3 newVel = movementDirection.normalized * moveSpeed + transform.up * rb.velocity.y;
        rb.velocity = newVel;
    }
}
