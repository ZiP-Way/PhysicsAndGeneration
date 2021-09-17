using UnityEngine;

public class FigurePartsLoader : MonoBehaviour
{
    private static FigurePart[] _figurePartPrefabs;

    private void Awake()
    {
        _figurePartPrefabs = Resources.LoadAll<FigurePart>("FigureParts");
    }

    public static FigurePart GetRandomPart()
    {
        return _figurePartPrefabs[Random.Range(0, _figurePartPrefabs.Length)];
    }
}
