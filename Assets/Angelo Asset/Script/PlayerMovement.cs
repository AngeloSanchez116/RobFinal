using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRb;
    public float speed;
    public float runSpeed;
    public float walkSpeed;
    public float jumpforce;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool isground;
    // Update is called once per frame
    void Update()
    {
        isground = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
        PlayerControl();

        if (Input.GetKeyDown(KeyCode.Space) && isground) {

            Jump();
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {

            run();
        }
        if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W)) {

            walking();
        }
    }

    public void PlayerControl() {

        float m_Horizontal = Input.GetAxis("Horizontal");
        float m_Vertical = Input.GetAxis("Vertical");

        Vector3 Movement = transform.right * m_Horizontal + transform.forward * m_Vertical;

        playerRb.AddForce(Movement * speed * Time.deltaTime, ForceMode.Impulse);
    }

    public void Jump() {

        playerRb.AddForce(transform.up * jumpforce ); 
    }

    public void run() {

        speed = runSpeed;
    
    }

    public void walking() {

        speed = walkSpeed;
    
    }
}
