using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private Rigidbody _rigidbody;
    private MeshFilter _meshFilter;

    private bool _isHitted = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _meshFilter = GetComponent<MeshFilter>();
    }

    public void AddForce(Vector3 force, ForceMode forceMode)
    {
        _rigidbody.isKinematic = false;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(force, forceMode);
    }

    public void SetMesh(Mesh mesh) => _meshFilter.mesh = mesh;


    private void OnEnable()
    {
        _isHitted = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_isHitted)
        {
            _isHitted = true;

            if (collision.transform.parent)
            {
                Target target = collision.transform.parent.GetComponent<Target>();

                if (target)
                {
                    target.SetKinematicForAllParts(false);
                    Explosion();
                }
            }

            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 1);
    }

    private void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 10, layerMask);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (Vector3.Distance(transform.position, colliders[i].transform.position) < 1)
            {
                colliders[i].gameObject.SetActive(false);
                continue;
            }

            Rigidbody rigidbody = colliders[i].GetComponent<Rigidbody>();
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(500, transform.position, 10);
            }
        }
    }
}
