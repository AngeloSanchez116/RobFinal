using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalProperties : MonoBehaviour
{
    private GameObject player;
    private GameObject gameControllerRef;
    public GameObject respawn;
    public GameObject portal;
    public float speed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameControllerRef = GameObject.FindGameObjectWithTag("GameController");
    }

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
            speed = 30;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //move scenes or location
            //collision.gameObject.transform.position = respawn.transform.position;
            player.transform.position = respawn.transform.position;
            player.transform.rotation = respawn.transform.rotation;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameControllerRef.GetComponent<GameController>().levelSpawCounter++;
        }
    }
}
