using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioScaling : MonoBehaviour
{
    public Slider s;
    //public float sliderModifier;
    public float initialVolume;
    public AudioSource audiSource;
    void Start()
    {
        initialVolume = audiSource.volume; 
    }

    // Update is called once per frame
    void Update()
    {
        audiSource.volume = initialVolume * s.value;
    }
}
