﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFloat : MonoBehaviour
{

    public float amplitude = 0.01f;
    public float frequency = 0.5f;

    //position storage values
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Update is called once per frame
    void FixedUpdate()
    {
             // Float up/down with a Sin()
             posOffset = transform.position;
             tempPos = posOffset;
             tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

             transform.position = tempPos;
    }
}
