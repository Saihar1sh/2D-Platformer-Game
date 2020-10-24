using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance {  get { return instance; } }

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

}

[Serializable]
public class SoundName
{
    public Sounds soundName;
    public AudioClip soundClip;
}
public enum Sounds
{
    buttonHover,
    buttonClick,
    theme,

}
