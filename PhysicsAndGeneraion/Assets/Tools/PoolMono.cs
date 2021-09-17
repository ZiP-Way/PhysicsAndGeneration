using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour
{
    private T _prefab;
    private Transform _container;
    
    private List<T> _elements;

    public PoolMono(int count, T prefab, Transform container)
    {
        _prefab = prefab;
        _container = container;
        CreatePool(count);
    }

    public T GetFreeElement()
    {
        foreach (T element in _elements)
        {
            if (!element.gameObject.activeInHierarchy)
            {
                return element;
            }
        }

        return CreateElement();
    }

    private void CreatePool(int count)
    {
        _elements = new List<T>();

        for (int i = 0; i < count; i++)
        {
            CreateElement();
        }
    }

    private T CreateElement()
    {
        T element = GameObject.Instantiate(_prefab.gameObject, _container).GetComponent<T>();

        if(element)
        {
            element.gameObject.SetActive(false);
            _elements.Add(element);
            return element;
        }

        throw new System.Exception($"{typeof(T)} Created pool element is null");
    }
}
