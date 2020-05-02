using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRunning : MonoBehaviour
{
    public bool canWallRunning;
    private Rigidbody playerRB;
    public Animator anim;
    public Camera parkourCamera;
    public Camera MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        parkourCamera.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canWallRunning && Input.GetKeyDown(KeyCode.E))
        {
            parkourCamera.GetComponent<Animator>().enabled = true;
            MainCamera.depth = 0;
            parkourCamera.depth = 1;
            playerRB.isKinematic = true;
            GetComponent<PlayerController>().enabled = false;
            anim.SetTrigger("WallRuning");
            StartCoroutine(afterWallRunning());
        }
    }

    IEnumerator afterWallRunning()
    {
        yield return new WaitForSeconds(1.5f);
        MainCamera.depth = 1;
        parkourCamera.depth = 0;
        playerRB.isKinematic = false;
        GetComponent<PlayerController>().enabled = true;
        transform.position = parkourCamera.transform.position;
        parkourCamera.GetComponent<Animator>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("I have collided with the trigger");
        if (other.tag == "WallRuning")
        {
            canWallRunning = true;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "WallRuning")
        {
            canWallRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canWallRunning = false;
    }
}
