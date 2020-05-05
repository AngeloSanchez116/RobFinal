using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFxManger : MonoBehaviour
{
    public AudioSource SoundFx;
    public List<AudioClip> audioclipfx;
    public int currentSoundFx = 0;
    public bool spaceBar = false;
    public bool wasgrounded;

    // Start is called before the first frame update
    void Start()
    {
        SoundFx.Stop();
        wasgrounded = GetComponent<PCroller>().isGrounded;
    }

    // Update is called once per frame
    void Update()
    {
        //SoundFx.pitch = 1f;

        if (Input.GetKeyDown(KeyCode.Space) && !SoundFx.isPlaying) {

            ChangesoundFX(audioclipfx[0]);
            
        }
        //is not working the way i want it
        if (!SoundFx.isPlaying && GetComponent<PCroller>().isGrounded == true && !wasgrounded)
        {
            ChangesoundFX(audioclipfx[1]);
            
        }
        else {

            wasgrounded = GetComponent<PCroller>().isGrounded;
        }

        if (Input.GetKey(KeyCode.W) && !SoundFx.isPlaying && GetComponent<PCroller>().isGrounded == true) {

            int n = Random.Range(3,4);
            SoundFx.clip = audioclipfx[n];
            SoundFx.PlayOneShot(SoundFx.clip);
            // move picked sound to index 0 so it's not picked next time
            audioclipfx[n] = audioclipfx[2];
            audioclipfx[2] = SoundFx.clip;
        }
        if (Input.GetKey(KeyCode.D) && !SoundFx.isPlaying && GetComponent<PCroller>().isGrounded == true)
        {

            int n = Random.Range(3, 4);
            SoundFx.clip = audioclipfx[n];
            SoundFx.PlayOneShot(SoundFx.clip);
            // move picked sound to index 0 so it's not picked next time
            audioclipfx[n] = audioclipfx[2];
            audioclipfx[2] = SoundFx.clip;

        }
        if (Input.GetKey(KeyCode.A) && !SoundFx.isPlaying && GetComponent<PCroller>().isGrounded == true)
        {

            int n = Random.Range(3, 4);
            SoundFx.clip = audioclipfx[n];
            SoundFx.PlayOneShot(SoundFx.clip);
            // move picked sound to index 0 so it's not picked next time
            audioclipfx[n] = audioclipfx[2];
            audioclipfx[2] = SoundFx.clip;

        }
        if (Input.GetKey(KeyCode.S) && !SoundFx.isPlaying && GetComponent<PCroller>().isGrounded == true)
        {

            int n = Random.Range(3, 4);
            SoundFx.clip = audioclipfx[n];
            SoundFx.PlayOneShot(SoundFx.clip);
            // move picked sound to index 0 so it's not picked next time
            audioclipfx[n] = audioclipfx[2];
            audioclipfx[2] = SoundFx.clip;

        }

        // need to  fix sound from playing to fast
         if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && GetComponent<PCroller>().isGrounded == true) {

            //SoundFx.pitch = 0.9f;
            ChangesoundFX(audioclipfx[5]);
        }

        if (GetComponent<ClimbUp>().canClimb == true && Input.GetKey(KeyCode.E)) {

            ChangesoundFX(audioclipfx[4]);
        
        }
        
    }

    public void ChangesoundFX(AudioClip SFX) {

        SoundFx.Stop();
        SoundFx.clip = SFX;
        SoundFx.PlayOneShot(SoundFx.clip);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WallRunner") {

            ChangesoundFX(audioclipfx[6]);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "WallRunner")
        {

            SoundFx.Stop();

        }
    }
}
