using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomHeadBob : MonoBehaviour
{
    public Camera Camera;
    public NewCurveBob motionBob = new NewCurveBob();
    public NewLerpBob jumpAndLandingBob = new NewLerpBob();
    public Rigidbody playerRb;
    private GameObject thePlayer;
    private PCroller playerController;

    //public RigidbodyFirstPersonController rigidbodyFirstPersonController;
    public float StrideInterval;
    [Range(0f, 1f)] public float RunningStrideLengthen;

    // private CameraRefocus m_CameraRefocus;
    private bool m_PreviouslyGrounded;
    private Vector3 m_OriginalCameraPosition;


    private void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        playerController = thePlayer.GetComponent<PCroller>();
        motionBob.Setup(Camera, StrideInterval);
        m_OriginalCameraPosition = Camera.transform.localPosition;
        //     m_CameraRefocus = new CameraRefocus(Camera, transform.root.transform, Camera.transform.localPosition);
    }


    private void Update()
    {
        //  m_CameraRefocus.GetFocusPoint();
        Vector3 newCameraPosition;
        if (playerRb.velocity.magnitude > 0 && !playerController.inAir)
        {
            Camera.transform.localPosition = motionBob.DoHeadBob(playerRb.velocity.magnitude * (playerController.isRunning ? RunningStrideLengthen : 1f));
            newCameraPosition = Camera.transform.localPosition;
            newCameraPosition.y = Camera.transform.localPosition.y - jumpAndLandingBob.Offset();
        }
        else
        {
            newCameraPosition = Camera.transform.localPosition;
            newCameraPosition.y = m_OriginalCameraPosition.y - jumpAndLandingBob.Offset();
        }
        Camera.transform.localPosition = newCameraPosition;

        if (!m_PreviouslyGrounded && !playerController.inAir)
        {
            StartCoroutine(jumpAndLandingBob.DoBobCycle());
        }

        m_PreviouslyGrounded = !playerController.inAir;
        //  m_CameraRefocus.SetFocusPoint();
    }
}
