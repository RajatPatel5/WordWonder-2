using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager inst;
    [SerializeField] AudioSource Source;
    public Sound[] clips;
    public AudioSource Bg_Source;
    public GameObject MusicMute;
    public GameObject MusicUnmute;
    public GameObject Sound_Mute;
    public GameObject Sound_Unmute;

    public void Awake()
    {
        inst = this;
    }

   public void PlaySound(SoundName name)
    {
        foreach (var item in clips)
        {
            if (item.name == name)
            {
                Source.PlayOneShot(item.clip);
                break;
            }
        }
    }

   

    public void musicMute(bool val)
    {
        Bg_Source.mute = val;
        MusicMute.SetActive(true);
        MusicUnmute.SetActive(false);

    }

    public void Music_Unmute(bool val)
    {
        Bg_Source.mute = val;
        MusicMute.SetActive(false);
        MusicUnmute.SetActive(true);

    }

    public void SoundMute(bool val)
    {
        Source.mute = val;
        Sound_Mute.SetActive(true);
        Sound_Unmute.SetActive(false);
    }

    public void SoundUnmute(bool val)
    {
        Source.mute = val;
        Sound_Mute.SetActive(false);
        Sound_Unmute.SetActive(true);
    }

   
}

[System.Serializable]
public class Sound
{
    public SoundName name;
    public AudioClip clip;
}

public enum SoundName
{
    Stone_Broke,
    GameOver

}

