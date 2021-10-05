using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTesting : MonoBehaviour
{
    public ParticleSystem testPart;
    public AudioSource audsource;
    public AudioClip audclip;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if(audsource.isPlaying)
        {
            print("playing");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audsource.PlayOneShot(audclip);
        }
        
    }
}
