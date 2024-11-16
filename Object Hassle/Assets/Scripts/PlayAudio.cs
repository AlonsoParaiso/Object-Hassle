using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip audioClip;
    public bool isLoop, playOnStart;
    public float volume;
    public string gameObjectName;

    // Start is called before the first frame update
    void Start()
    {
        if (playOnStart)//hace que funcione el audio
        {
            AudioManager.instance.PlayAudio(audioClip, gameObjectName, isLoop, volume);
        }
    }
}
