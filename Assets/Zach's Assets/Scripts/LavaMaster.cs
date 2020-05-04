using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaMaster : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(0);
        }
    }
}
