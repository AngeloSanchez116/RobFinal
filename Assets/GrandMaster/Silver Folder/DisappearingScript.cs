using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingScript : MonoBehaviour
{
    public GameObject disappearingPlatform;
    public int disappearingTmer = 0;
    public int appearingTmer = 0;
    public AudioSource audiosource;

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && gameObject.tag == "Disappear")
        {   
            audiosource.Play();
            yield return new WaitForSeconds(disappearingTmer);//wait x amount of seconds
            disappearingPlatform.GetComponent<MeshRenderer>().enabled = false;
            disappearingPlatform.GetComponent<BoxCollider>().enabled = false;
            
        }
    }

    IEnumerator OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && gameObject.tag == "Disappear")
        {
            audiosource.Stop();
            yield return new WaitForSeconds(appearingTmer);//wait x amount of seconds
            disappearingPlatform.GetComponent<MeshRenderer>().enabled = true;
            disappearingPlatform.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
