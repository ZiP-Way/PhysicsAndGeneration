using UnityEngine;

public class FiguresGenerator : MonoBehaviour
{
    [Header("Generation Settings")]
    [SerializeField] private int _count; 
    [SerializeField] private float _radius; 

    [SerializeField] private Figure[] _typeOfFigures;

    private void Start()
    {
        Generate();
    }

    private void Generate()
    {
        for (int i = 0; i < _count; i++)
        {
            float angle = i * Mathf.PI * 2f / _count;

            Vector3 newPos = new Vector3(Mathf.Cos(angle) * _radius, 0.5f, Mathf.Sin(angle) * _radius);
            GetRandomFigure().Generate(transform, newPos);
        }
    }

    private Figure GetRandomFigure()
    {
        return _typeOfFigures[Random.Range(0, _typeOfFigures.Length)];
    }

}
