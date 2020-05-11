using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private GameObject player;
    public GameObject respawn;
    private GameObject lavaFloor;
    private GameObject updownPlat;
    public GameObject LavaTriggerRef;
    private float timer;
    public bool turnOnOffLava = true;
    public int levelSpawCounter = 0;

    ////////////////////////////////////////////////////
    //A group of all the respawning gameobject

    public GameObject respawning;
    public GameObject respawning1;
    public GameObject respawning2;
    public GameObject respawning3;
    public GameObject respawning4;
    ///////////////////////////////////////////////////

    // Start is called be fore the first frame update
    void Start()
    {
        lavaFloor = GameObject.FindGameObjectWithTag("Lava");
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = respawn.transform.position;
        player.transform.rotation = respawn.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;

        if (turnOnOffLava == true) 
        { 
            lavaFloor.transform.position += new Vector3(0, timer, 0);
            lavaFloor.GetComponent<AudioSource>().enabled = true;
            if (LavaTriggerRef.GetComponent<AudioSource>().isPlaying == false) {
                LavaTriggerRef.SetActive(false);
            }
            if (player.transform.position.y < lavaFloor.transform.position.y - 2) {

                if (levelSpawCounter == 0) {

                    turnOnOffLava = false;
                    lavaFloor.GetComponent<AudioSource>().enabled = false;
                    LavaTriggerRef.SetActive(true);
                    lavaFloor.transform.position = new Vector3(472.2176f, -10.2f, 444.5937f);
                    player.transform.position = new Vector3(484.51f, 3.89f, 276.17f);
                }

                if (levelSpawCounter == 1) {
                    player.transform.position = respawning.transform.position;
                    lavaFloor.transform.position = new Vector3(472.2176f, 63.1f, 444.5937f);
                }

                if (levelSpawCounter == 2)
                {
                    player.transform.position = respawning1.transform.position;
                    lavaFloor.transform.position = new Vector3(472.2176f, 108.4f, 444.5937f);
                }

                if (levelSpawCounter == 3)
                {
                    player.transform.position = respawning2.transform.position;
                    lavaFloor.transform.position = new Vector3(472.2176f, 150.8f, 444.5937f);
                }

                if (levelSpawCounter == 4)
                {
                    player.transform.position = respawning3.transform.position;
                    lavaFloor.transform.position = new Vector3(472.2176f, 192.6f, 444.5937f);
                }
                if (levelSpawCounter == 5)
                {
                    player.transform.position = respawning4.transform.position;
                    lavaFloor.transform.position = new Vector3(472.2176f, 221f, 444.5937f);
                }
            }
        }

    }

}
