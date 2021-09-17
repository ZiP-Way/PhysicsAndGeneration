using UnityEngine;

public class FigurePart : MonoBehaviour
{
    public bool IsKinematic
    {
        get
        {
            return _rigidbody.isKinematic;
        }
        set
        {
            if(_rigidbody == null)
            {
                _rigidbody = GetComponent<Rigidbody>();
            }
            _rigidbody.isKinematic = value;
        }
    }

    private Rigidbody _rigidbody;
}
