using UnityEngine;

public class FootStepsSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void PlayFootstep()
    {
        _audioSource.pitch = Random.Range(0.8f, 1f);
        _audioSource.PlayOneShot(_audioSource.clip);
    }
}