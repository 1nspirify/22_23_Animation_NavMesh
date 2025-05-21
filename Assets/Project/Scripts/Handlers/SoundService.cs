using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundService : MonoBehaviour
{
    private const float OnVolumeValue = 0f;
    private const float OffVolumeValue = -80f;
    
    private const string SoundKey = "Sound";
    private const string MusicKey = "Music";
    
    [SerializeField] AudioSource _audioSource;
    
}