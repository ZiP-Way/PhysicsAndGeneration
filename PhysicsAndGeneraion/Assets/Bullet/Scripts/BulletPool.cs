using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public Bullet Bullet
    {
        get
        {
            Bullet bullet = _pool.GetFreeElement();

            bullet.SetMesh(_kindsOfBullet[Random.Range(0, _kindsOfBullet.Length)]);
            bullet.gameObject.SetActive(true);

            return bullet;
        }
    }

    [Header("Pool Settings")]
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _container;
    [SerializeField] private int _count;

    [Header("Bullet Settings")]
    [SerializeField] private Mesh[] _kindsOfBullet;

    private PoolMono<Bullet> _pool;

    private void Awake()
    {
        _pool = new PoolMono<Bullet>(_count, _prefab, _container);
    }

}
