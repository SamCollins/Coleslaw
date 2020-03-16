using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    private static float frameRate = 60;

    public Vector3 move;
    public float moveSpeed = 1.0f;
    public float maxSpeed = 20.0f;
    public float aerialMaxSpeed = 10.0f;

    public Vector3 jump;
    public float jumpHeight = 3.0f;

    public Vector3 directionVector = new Vector3();
    
    public bool isGrounded;
    private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();

        jump = new Vector3(0, 3.0f, 0);

        moveSpeed *= frameRate;

    }

    // Update is called once per frame
    void Update()
    {
        //directionVector = Vector3.zero;

        directionVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        CheckJump();
        MoveCube(directionVector);
    }

    private void MoveCube(Vector3 direction)
    {
        //if (!isGrounded)
        //{
        //    direction *= 0.5f;
        //}

        //direction *= frameRate;

        //Need to figure how to put Time.deltaTime here
        //body.MovePosition(transform.position + direction.normalized * moveSpeed * Time.deltaTime);

        transform.Translate(moveSpeed * direction.normalized * Time.deltaTime);
    }

    private void SetMaxSpeed()
    {
        if (!isGrounded)
        {
            if (body.velocity.magnitude > aerialMaxSpeed)
                body.velocity = body.velocity.normalized * aerialMaxSpeed;
        }
        else
        {
            if (body.velocity.magnitude > maxSpeed)
                body.velocity = body.velocity.normalized * maxSpeed;
        }
    }

    private void CheckJump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            body.AddForce(transform.up * jumpHeight, ForceMode.VelocityChange);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.gameObject;
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
