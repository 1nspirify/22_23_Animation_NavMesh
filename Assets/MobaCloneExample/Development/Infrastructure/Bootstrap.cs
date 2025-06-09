using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private MainHeroSpawner _heroSpawner;
    [SerializeField] private EnemiesSpawner _enemiesSpawner;

    private void Awake()
    {
        Character mainHero = _heroSpawner.Spawn();
        _enemiesSpawner.Spawn(mainHero.transform);
    }
}