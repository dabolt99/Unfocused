using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFXAudioSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer volume;

    public void SetVolume(float sliderValue){
        volume.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
    }
}
