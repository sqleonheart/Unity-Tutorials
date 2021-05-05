using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private SphereCollider sphereColl;
    public float movementSpeed = 10f;
    public float jumpForce = 10f;
    public bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        sphereColl = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalBoost = 50f;
        float verticalBoost = 50f;
        

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            horizontalInput *= horizontalBoost;
            verticalInput *= verticalBoost;
        }

        playerRb.AddForce(Vector3.right * horizontalInput * movementSpeed * Time.deltaTime, ForceMode.Force);
        playerRb.AddForce(Vector3.forward * verticalInput * movementSpeed * Time.deltaTime, ForceMode.Force);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody == CompareTag("Finish"))
        {
            isGrounded = true;
        }
    }
}
