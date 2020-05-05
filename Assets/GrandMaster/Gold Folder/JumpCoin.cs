using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCoin : MonoBehaviour
{
    public float rotationSpeed;
    private GameObject Player;

    public float amplitude = 0.01f;
    public float frequency = 0.5f;
    //position storage values
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Rotate
        transform.Rotate(0, 0, rotationSpeed);

        // Float up/down with a Sin()
        posOffset = transform.position;
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            print("I collected a power up");
            Destroy(gameObject);
            Player.GetComponent<PCroller>().jumpMax++;
        }
    }
}
