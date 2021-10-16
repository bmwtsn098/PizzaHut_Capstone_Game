﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    
    public void setVolume(float volume)
    {

        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }
}
