using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbUp : MonoBehaviour
{
    public bool canClimb;
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
        if(canClimb && Input.GetKeyDown(KeyCode.E))
        {
            parkourCamera.GetComponent<Animator>().enabled = true;
            MainCamera.depth = 0;
            parkourCamera.depth = 1;
            playerRB.isKinematic = true;
            GetComponent<PCroller>().enabled = false;
            anim.SetTrigger("Climb");
            StartCoroutine(afterClimb());
        }
    }

    IEnumerator afterClimb()
    {
        yield return new WaitForSeconds(1);
        MainCamera.depth = 1;
        parkourCamera.depth = 0;
        playerRB.isKinematic = false;
        GetComponent<PCroller>().enabled = true;
        transform.position = parkourCamera.transform.position;
        parkourCamera.GetComponent<Animator>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Climb")
        {
            print("I can Climb here");
            canClimb = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Climb")
        {
            canClimb = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canClimb = false;
    }
}
