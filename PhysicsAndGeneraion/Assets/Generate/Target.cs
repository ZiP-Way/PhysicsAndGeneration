using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public List<FigurePart> Parts
    {
        set
        {
            if (_parts != null)
            {
                _parts = value;
            }
        }
    }

    private List<FigurePart> _parts;

    private void Awake()
    {
        _parts = new List<FigurePart>();
    }

    public void SetKinematicForAllParts(bool isKinematic)
    {
        foreach (var part in _parts)
        {
            part.IsKinematic = isKinematic;
        }
    }
}
