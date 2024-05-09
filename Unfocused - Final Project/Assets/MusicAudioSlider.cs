using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicAudioSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer volume;

    public void SetVolume(float sliderValue){
        volume.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }
}
