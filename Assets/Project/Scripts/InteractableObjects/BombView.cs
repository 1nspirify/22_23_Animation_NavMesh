using UnityEngine;

public class BombView : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explodeParticles;

    public void Explosion()
    {
        Instantiate(_explodeParticles, transform.position, Quaternion.identity);
    }
}