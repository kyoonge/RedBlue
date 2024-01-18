using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgmAudioSource;

    void Awake()
    {
        GameManager.Instance.soundManager = this;
        // ��� ���� ���
        bgmAudioSource.Play();
    }
}
