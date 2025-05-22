using UnityEngine;
using UnityEngine.Audio;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    private AudioService _audioService;

    private void Awake()
    {
        _audioService = new AudioService(_audioMixer);
    }

    public void SoundSwitcher()
    {
        if (_audioService.IsSoundOn() == false)
            _audioService.SoundOn();
        else
        {
            _audioService.SoundOff();
        }
    }

    public void MusicSwitcher()
    {
        if (_audioService.IsMusicOn() == false)
            _audioService.MusicOn();
        else
        {
            _audioService.MusicOff();
        }
    }
}