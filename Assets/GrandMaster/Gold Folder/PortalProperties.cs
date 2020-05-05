using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalProperties : MonoBehaviour
{
    public GameObject respawn;
    public GameObject portal;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        portal.transform.Rotate(0, speed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gameObject.GetComponentInChildren<Renderer>().enabled = true;
            speed = 10;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //move scenes or location
            //collision.gameObject.transform.position = respawn.transform.position;
            SceneManager.LoadScene(0);
        }
    }
}
