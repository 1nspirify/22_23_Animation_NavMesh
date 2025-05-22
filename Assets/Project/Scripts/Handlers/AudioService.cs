using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioService 
{
    private const float OnVolumeValue = 0f;
    private const float OffVolumeValue = -80f;

    private const string SoundKey = "Sound";
    private const string MusicKey = "Music";

    [SerializeField] AudioMixer _audioMixer;

    public AudioService(AudioMixer audioMixer)
    {
        _audioMixer = audioMixer;
    }

    public bool IsMusicOn() => IsVolumeOn(MusicKey);
    public bool IsSoundOn() => IsVolumeOn(SoundKey);

    public void MusicOn() => VolumeOn(MusicKey);
    public void MusicOff() => VolumeOff(MusicKey);

    public void SoundOn() => VolumeOn(SoundKey);
    public void SoundOff() => VolumeOff(SoundKey);

    private bool IsVolumeOn(string key) =>
        _audioMixer.GetFloat(key, out float volume) && Mathf.Abs(volume - OnVolumeValue) <= 0.01f;

    private void VolumeOn(string key) => _audioMixer.SetFloat(key, OnVolumeValue);
    private void VolumeOff(string key) => _audioMixer.SetFloat(key, OffVolumeValue);
}