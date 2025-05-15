using UnityEngine;

public class Fireball : MonoBehaviour
{
    private readonly int _fireballTrigger = Animator.StringToHash("Fireball");
    [SerializeField] private FireBullet _fireballPrefab;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _castFireball;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger(_fireballTrigger);
        }
    }

    private void CastFireball()
    {
        FireBullet fireball = Instantiate(_fireballPrefab, _castFireball.position, _castFireball.rotation);
        fireball.Lounch(5f, 10f);
    }
}