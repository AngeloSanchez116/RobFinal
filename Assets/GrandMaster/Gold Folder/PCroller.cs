using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCroller : MonoBehaviour
{
    public Rigidbody playerRb;
    public CapsuleCollider p_Collider;

    public float stoppingFriction;
    public float airResistance;

    public float runSpeedX;
    public float movementMasterSpeed;
    public float movementSpeed;
    public float turningSpeed;
    public float straffingSpeed;

    public float jumpForce;
    private float jumpX;
    public int jumpMax;
    private int jumps;

    public bool inAir = false;
    public bool isRunning = false;
    public bool isJumping = false;
    public bool isGrounded;
    //private Vector3 GroundContactNormal;

        public float groundCheckDistance = 0.01f; // distance for checking if the controller is grounded ( 0.01f seems to work best for this )
        public float stickToGroundHelperDistance = 0.5f; // stops the character
        //[Tooltip("set it to 0.1 or more if you get stuck in wall")]
        public float shellOffset; //reduce the radius by that ratio to avoid getting stuck in wall (a value of 0.1f is nice)
        

    private void Start()
    {
        jumpX = jumpForce * 1000;
        p_Collider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inAir && !Input.anyKey)
        {
            //print("Nothing is being pressed");
            playerRb.drag = stoppingFriction;
            isRunning = false;
        }
        else
        {
            playerRb.drag = 1f;
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
        float rotHorizontal = Input.GetAxis("Mouse X") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, rotHorizontal, 0);

        PlayerControl();
        GroundCheck();

        if(inAir)
        {
            playerRb.drag = .5f;
            if (isGrounded && !isJumping)
            {
                StickToGroundHelper();
            }
        }
    }

    public void PlayerControl()
    {
        /////////////////////////////////MOVEMENT CONTROLS///////////////////////////////////////////////////////

        float m_Horizontal = Input.GetAxisRaw("Horizontal") * straffingSpeed;
        //transform.Translate(m_Horizontal, 0, 0);
        //Vector3 MovementH = transform.right * m_Horizontal;

        float m_Vertical = Input.GetAxisRaw("Vertical");
        //transform.Translate(0, 0, m_Vertical);
        //Vector3 MovementV = transform.forward * m_Vertical;
        
        if(m_Vertical < 0)
        {
            m_Vertical *= .8f;
        }

        Vector3 Movement = transform.right * m_Horizontal + transform.forward * m_Vertical;
        //playerRb.velocity = MovementH * movementSpeed * Time.deltaTime;
        playerRb.AddForce(Movement * movementSpeed, ForceMode.Impulse);

        //playerRb.AddForce(MovementH * movementSpeed, ForceMode.Impulse);
        //playerRb.AddForce(MovementV * movementSpeed, ForceMode.Impulse);
        
    }

    public void Jump()
    {
        if (jumps < jumpMax)
        {
            playerRb.AddForce(transform.up * jumpX);
            jumps++;
            isJumping = true;
        }
    }

    public void run()
    {
        isRunning = true;
        playerRb.drag = 1;

        if (inAir == true)
        {
            movementSpeed = (movementMasterSpeed / airResistance) * runSpeedX;
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
            movementSpeed = movementMasterSpeed / airResistance;
        }
        else
        {
            movementSpeed = movementMasterSpeed;
        }
    }

    private void GroundCheck()
    {

        isGrounded = !inAir;
        RaycastHit hitInfo;
        if (Physics.SphereCast(transform.position, p_Collider.radius * (1.0f - shellOffset), Vector3.down, out hitInfo,
                               ((p_Collider.height / 2f) - p_Collider.radius) + groundCheckDistance, Physics.AllLayers, QueryTriggerInteraction.Ignore))
        {
            inAir = false;
            jumps = 0;
            /*if (!GetComponent<SoundFxManger>().SoundFx.isPlaying) {
                GetComponent<SoundFxManger>().SoundFx.PlayOneShot(GetComponent<SoundFxManger>().audioclipfx[1]);
            }*/
            //GroundContactNormal = hitInfo.normal;
        }
        else
        {
            inAir = true;
            jumps = 1;
            //GroundContactNormal = Vector3.up;
        }
        if (!isGrounded && inAir && isJumping)
        {
            isJumping = false;
        }
    }

    private void StickToGroundHelper()
    {
        RaycastHit hitInfo;
        if (Physics.SphereCast(transform.position, p_Collider.radius * (1.0f - shellOffset), Vector3.down, out hitInfo,
                               ((p_Collider.height / 2f) - p_Collider.radius) + stickToGroundHelperDistance, Physics.AllLayers, QueryTriggerInteraction.Ignore))
        {
            if (Mathf.Abs(Vector3.Angle(hitInfo.normal, Vector3.up)) < 85f)
            {
                playerRb.velocity = Vector3.ProjectOnPlane(playerRb.velocity, hitInfo.normal);
            }
        }
    }

}
