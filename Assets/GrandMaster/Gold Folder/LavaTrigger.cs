using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTrigger : MonoBehaviour
{
    public GameObject gameController;
    public AudioClip rumble;
    AudioSource audioSource;

    [Range(0.0f, 1.0f)] public float volume;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            audioSource.Play();
            gameController.GetComponent<GameController>().turnOnOffLava = true;
            
        }
    }
}
