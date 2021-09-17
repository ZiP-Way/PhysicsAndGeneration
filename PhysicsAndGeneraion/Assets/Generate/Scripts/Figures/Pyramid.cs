using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pyramid", menuName = "Figures/New Pyramid")]
public class Pyramid : Figure
{
    [SerializeField] private int _sideSize;
    
    public override Figure Generate(Transform container, Vector3 position)
    {
        GameObject figure = Initialization("Pyramid", container, position);

        List<FigurePart> parts = new List<FigurePart>();

        for (int y = 0; y < _sideSize; y++)
        {
            for (int z = y; z < _sideSize - y; z++)
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
