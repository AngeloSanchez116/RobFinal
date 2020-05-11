using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    public GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
        {
            Player.transform.parent = transform;
            Player.GetComponentInChildren<CustomHeadBob>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == Player)
        {
            Player.transform.parent = null;
            Player.transform.localScale = new Vector3(1, 1, 1);
            Player.GetComponentInChildren<CustomHeadBob>().enabled = true;
        }
    }
}
