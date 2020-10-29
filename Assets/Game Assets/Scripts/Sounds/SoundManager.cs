using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance {  get { return instance; } }

    public AudioSource soundEffect, soundMusic;

    public bool isMute = false;

    public SoundType[] Sounds;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        PlayMusic(global::Sounds.theme);
    }

    public void Mute(bool status)
    {
        isMute = status;
    }
    public void Play(Sounds sound)
    {
        if (isMute)
            return;

        AudioClip clip = getSoundClip(sound);
        if(clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Clip not found for sound type" + sound);
        }
    }
    public void PlayMusic(Sounds sound)
    {
        if (isMute)
            return;

        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }
        else
        {
            Debug.LogError("Clip not found for sound type" + sound);
        }
    }


    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(Sounds, i => i.soundName == sound);
        if (item != null)
            return item.soundClip;
        return null;
    }
}


[Serializable]
public class SoundType
{
    public Sounds soundName;
    public AudioClip soundClip;
}
public enum Sounds
{
    buttonClick,
    buttonStart,
    buttonBack,
    buttonInvalid,
    buttonPause,
    theme,
    pickup,
    playerMove,
    playerJump,
    playerDeath,
    teleportUse,
    spikeImpact,
    checkPoint,
    playerHurt,
    hiddenArea

}
