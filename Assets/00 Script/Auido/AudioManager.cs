using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioSource MusicSource;

    [SerializeField] AudioSource SFXSource;

    [SerializeField] List<AudioClip> _listAudio = new List<AudioClip>();
    void Start()
    {
        MusicSource.clip = _listAudio[0]; ;
        MusicSource.Play();
    }

    // Update is called once per frame
    public void SetSFX(int index)
    {
        SFXSource.PlayOneShot(_listAudio[index]);
    }
}
