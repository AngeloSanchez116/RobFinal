using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardBreak : MonoBehaviour
{
    public AudioClip shardBreak;
    AudioSource audioSource;
    [Range(0.0f, 1.0f)] public float volume;

    private GameObject falseRuby;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        falseRuby = GameObject.FindGameObjectWithTag("Fire");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audioSource.Play();
            Destroy(falseRuby);
            StartCoroutine(breakSound());
        }
    }

    IEnumerator breakSound()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
