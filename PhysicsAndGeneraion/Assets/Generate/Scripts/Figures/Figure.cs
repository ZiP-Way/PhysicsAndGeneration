using System.Collections.Generic;
using UnityEngine;

public abstract class Figure : ScriptableObject
{
    public abstract Figure Generate(Transform container, Vector3 position);

    protected GameObject Initialization(string name, Transform container, Vector3 position)
    {
        GameObject figure = new GameObject("Pyramid");
        figure.transform.SetParent(container);
        figure.transform.position = position;

        return figure;
    }

    protected void SetTarget(List<FigurePart> figureParts, GameObject figure)
    {
        Target target = figure.AddComponent<Target>();
        target.Parts = figureParts;
        target.SetKinematicForAllParts(true);
    }
}
