using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rectangular Prism", menuName = "Figures/New Rectangular Prism")]
public class RectangularPrism : Figure
{
    [SerializeField] private int _height;
    [SerializeField] private int _width;

    public override Figure Generate(Transform container, Vector3 position)
    {
        GameObject figure = Initialization("Rectangular Prism", container, position);

        List<FigurePart> parts = new List<FigurePart>();

        for (int z = 0; z < _width; z++)
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
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
