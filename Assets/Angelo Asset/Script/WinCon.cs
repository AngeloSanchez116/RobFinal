using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCon : MonoBehaviour
{
    public GameObject WinConReach;
    public GameObject gameControllerRef;
 
    private void Start()
    {
        gameControllerRef = GameObject.FindGameObjectWithTag("GameController");
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player") {

            
            gameControllerRef.GetComponent<GameController>().turnOnOffLava = false;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;

            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            WinConReach.SetActive(true);

            
        
        }
    }
}
