using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private BulletPool _bullets;

    public void Shoot()
    {
        Bullet bullet = _bullets.Bullet;
        bullet.transform.position = transform.position;
        bullet.AddForce(transform.forward * _force, ForceMode.Impulse);
    }
}
