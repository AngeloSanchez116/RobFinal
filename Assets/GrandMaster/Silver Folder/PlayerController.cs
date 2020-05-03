using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public Collider p_Collider;

    public float stoppingFriction;
    public float airResistance;
    public float runSpeedX;
    public float movementMasterSpeed;
    public float movementSpeed;
    public float turningSpeed;

    public float jumpForce;
    private float jumpX;
    public int jumpMax;
    private int jumps;

    public bool inAir = false;
    public bool isRunning = false;

    private void Start()
    {
        jumpX = jumpForce * 1000;
        p_Collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

        if (inAir == false && !Input.anyKey)
        {
            //print("Nothing is being pressed");
            playerRb.drag = stoppingFriction;
            isRunning = false;
        }
        else
        {
            playerRb.drag = 1;
        }
        

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            run();
        }
        if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W)) 
        {
            walking();
        }
    }

    private void FixedUpdate()
    {
        PlayerControl();
    }

    public void PlayerControl() 
    {
        /////////////////////////////////MOVEMENT CONTROLS///////////////////////////////////////////////////////
        float rotHorizontal = Input.GetAxis("Mouse X") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, rotHorizontal, 0);
        
        float m_Horizontal = Input.GetAxis("Horizontal");
        //transform.Translate(m_Horizontal, 0, 0);

        float m_Vertical = Input.GetAxis("Vertical");
        //transform.Translate(0, 0, m_Vertical);

        Vector3 Movement = transform.right * m_Horizontal + transform.forward * m_Vertical;
        playerRb.AddForce(Movement * movementSpeed, ForceMode.Impulse);


        //ANGELO'S MOVEMENT/Done through forces///////////////////////////////////////////////
        /*Vector3 Movement = transform.right * m_Horizontal + transform.forward * m_Vertical;
        playerRb.AddForce(Movement * speed * Time.deltaTime, ForceMode.Impulse);
        *////////////////////////////////////////////////////////////////////////////////////////////////////////

        //GHOST HEAD UP/DOWN MOVEMENT////////////////////////////////////////////////////////////////////////////
        /*var mouseDirection = new Vector2(rotHorizontal, Input.GetAxisRaw("Mouse Y"));

        mouseDirection = Vector2.Scale(mouseDirection, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, mouseDirection.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseDirection.y, 1f / smoothing);
        mouseLook += smoothV;

        mouseLook.y = Mathf.Clamp(mouseLook.y, -45f, 45f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);*/
        /////////////////////////////////////////////////////////////////////////////////////////////////////////


    }

    public void Jump() 
    {
        if(jumps < jumpMax)
        {
            playerRb.AddForce(transform.up * jumpX);
            jumps++;
        }
    }

    public void run() 
    {
        isRunning = true;
        playerRb.drag = 1;

        if (inAir == true)
        {
            movementSpeed = (movementMasterSpeed/airResistance) *runSpeedX;
        }
        else
        {
            movementSpeed = movementMasterSpeed * runSpeedX;
        }
    }

    public void walking() 
    {
        isRunning = false;
        playerRb.drag = 1;

        if (inAir == true)
        {
            movementSpeed = movementMasterSpeed/airResistance;
        }
        else
        {
            movementSpeed = movementMasterSpeed;
        }     
    }

    private void OnCollisionEnter(Collision collision)
    {
        inAir = false;
        jumps = 0;
        movementSpeed = movementMasterSpeed;
    }

    private void OnCollisionStay(Collision collision)
    {
        inAir = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        inAir = true;
    }
}
