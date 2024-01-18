using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgmAudioSource;

    void Awake()
    {
        GameManager.Instance.soundManager = this;
        // 배경 음악 재생
        bgmAudioSource.Play();
    }
}
