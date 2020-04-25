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

                SceneManager.LoadScene(0);

            }
        }
    }
}
