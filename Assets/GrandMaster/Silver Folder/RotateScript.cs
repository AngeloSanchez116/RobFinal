using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public float speed;
    public float xrotate;
    public float zrotate;

    float num = 0;
    // Update is called once per frame
    void Update()
    {
        num += Time.deltaTime;

        transform.Rotate(xrotate, speed, zrotate);

        if (num > 10) {

           speed = Random.Range(-0.9f, 1) * 2;
           xrotate = Random.Range(-0.9f, 1) * 2;
           zrotate = Random.Range(-0.9f, 1) * 2;
            num = 0;
        }

    }
}
