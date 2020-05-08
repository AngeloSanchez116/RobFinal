using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    private GameObject player;
    private GameObject gameControllerRef;
    public GameObject respawnbox;
    public float speed;
    public GameObject portal;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameControllerRef = GameObject.FindGameObjectWithTag("GameController");
        portal.transform.Rotate(0, speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponentInChildren<Renderer>().enabled = true;
            speed = 10;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            player.transform.position = respawnbox.transform.position;
            gameControllerRef.GetComponent<GameController>().levelSpawCounter++;
        }
    }
}
