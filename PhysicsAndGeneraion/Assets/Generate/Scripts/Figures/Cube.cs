using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cube", menuName = "Figures/New Cube")]
public class Cube : Figure
{
    [SerializeField] private int _sideSize;

    public override Figure Generate(Transform container, Vector3 position)
    {
        GameObject figure = Initialization("Cube", container, position);

        List<FigurePart> parts = new List<FigurePart>();

        for (int z = 0; z < _sideSize; z++)
        {
            for (int i = 0; i < _sideSize; i++)
            {
                for (int j = 0; j < _sideSize; j++)
                {
                    FigurePart part = Instantiate(FigurePartsLoader.GetRandomPart(), figure.transform);
                    part.transform.localPosition = new Vector3(j, i, z);
                    parts.Add(part);
                }
            }
        }

        SetTarget(parts, figure);
        return this;
    }
}
