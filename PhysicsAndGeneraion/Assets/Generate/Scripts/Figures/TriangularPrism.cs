using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Triangular Prism", menuName = "Figures/New Triangular Prism")]
public class TriangularPrism : Figure
{
    [SerializeField] private int _sideSize;

    public override Figure Generate(Transform container, Vector3 position)
    {
        GameObject figure = Initialization("Triangular Prism", container, position);

        List<FigurePart> parts = new List<FigurePart>();

        for (int z = 0; z < _sideSize; z++)
        {
            for (int y = 0; y < _sideSize; y++)
            {
                for (int x = y; x < _sideSize - y; x++)
                {
                    FigurePart part = Instantiate(FigurePartsLoader.GetRandomPart(), figure.transform);
                    part.transform.localPosition = new Vector3(x, y, z);
                    parts.Add(part);
                }
            }
        }

        SetTarget(parts, figure);
        return this;
    }
}
