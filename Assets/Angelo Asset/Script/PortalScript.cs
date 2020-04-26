using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    private GameObject player;
    private GameObject gameControllerRef;
    public GameObject respawnbox;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameControllerRef = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            player.transform.position = respawnbox.transform.position;
            gameControllerRef.GetComponent<GameController>().levelSpawCounter++;
        }
    }
}
