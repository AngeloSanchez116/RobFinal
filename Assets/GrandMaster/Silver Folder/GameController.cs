using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private GameObject player;
    private GameObject lavaFloor;
    private GameObject updownPlat;
    private float timer;
    public bool turnOnOffLava = true;
    public int levelSpawCounter = 0;

    ////////////////////////////////////////////////////
    //A group of all the respawning gameobject

    public GameObject respawning;
    public GameObject respawning1;
    public GameObject respawning2;
    public GameObject respawning3;

    ///////////////////////////////////////////////////

    // Start is called be fore the first frame update
    void Start()
    {
        lavaFloor = GameObject.FindGameObjectWithTag("Lava");
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;

        if (turnOnOffLava == true) 
        { lavaFloor.transform.position += new Vector3(0, timer, 0);

            if (player.transform.position.y < lavaFloor.transform.position.y - 2) {

                if (levelSpawCounter == 0) {
                    lavaFloor.transform.position = new Vector3(22.06f, 8f, -4.35f);
                    player.transform.position = new Vector3(37.95f,15.92f,-22.8f);
                }

                if (levelSpawCounter == 1) {
                    player.transform.position = respawning.transform.position;
                    lavaFloor.transform.position = new Vector3(22.06f, 46.3f, -4.35f);
                }

                if (levelSpawCounter == 2)
                {
                    player.transform.position = respawning1.transform.position;
                    lavaFloor.transform.position = new Vector3(22.06f, 87.2f, -4.35f);
                }

                if (levelSpawCounter == 3)
                {
                    player.transform.position = respawning2.transform.position;
                    lavaFloor.transform.position = new Vector3(22.06f, 130.6f, -4.35f);
                }

                if (levelSpawCounter == 4)
                {
                    player.transform.position = respawning3.transform.position;
                    lavaFloor.transform.position = new Vector3(22.06f, 161.7f, -4.35f);
                }
            }
        }
    }
}
