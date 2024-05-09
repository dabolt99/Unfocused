using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MasterAudioSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer volume;

    public void SetVolume(float sliderValue){
        volume.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
    }
}
