﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wRunner : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody playerRB;
    private Vector3 p_posY;
    private float y;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerRB = Player.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            p_posY = Player.transform.position;
            //y = Player.transform.position.y;
            //Player.transform.parent = transform;
            playerRB.useGravity = false;
            Player.GetComponent<PCroller>().inAir = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Player.transform.position = new Vector3(Player.transform.position.x, p_posY.y, Player.transform.position.z);
        //Player.transform.parent = transform;
        playerRB.useGravity = false;
        Player.GetComponent<PCroller>().inAir = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            //Player.transform.parent = null;
            playerRB.useGravity = true;
            Player.GetComponent<PCroller>().inAir = true;
        }
    }
}
