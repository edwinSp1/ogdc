using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private bool isTouchingGround = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isTouchingGround)
        {
            rb.velocity = new Vector3(rb.velocity.x, 10, rb.velocity.z);
        }
        /*
        if(Input.GetKey(KeyCode.W))
        {

            rb.velocity += new Vector3(0, 0, 0.1f); 
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity += new Vector3(-0.1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity += new Vector3(0, 0, -0.1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity += new Vector3(0.1f, 0, 0);
        }
        */
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        print(rb.rotation);
        Vector3 movementVector = Vector3.Normalize(transform.rotation * new Vector3(horizontalInput, 0, verticalInput)) * speed;
        rb.velocity = new Vector3(movementVector.x, rb.velocity.y, movementVector.z);
        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -10, 10),
                                  rb.velocity.y,
                                  Mathf.Clamp(rb.velocity.z, -10, 10)
                                );
    }
    private void OnCollisionEnter(Collision collision)
    {
        isTouchingGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isTouchingGround = false;
    }

}

