using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public void Lounch(float destroyTime, float force)
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
        Destroy(gameObject, destroyTime);
    }
}