using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log(Mathf.Max(volume, 0.001f)) * 20.0f);
    }

}
