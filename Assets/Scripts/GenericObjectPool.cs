using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T prefab;
    public static GenericObjectPool<T> Instance { get; private set;}
    private Queue<T> objects = new Queue<T>();

    private void Awake()
    {
        Instance = this;
    }

    // returns an object from the pool (Instantiates it if neccessary)
    public T Get()
    {
        Debug.Log("Get");
        if (objects.Count==0)
            AddObjects(1);
        return objects.Dequeue();
    }

    // instantiates new objects and adds them to the pool
    private void AddObjects(int count)
    {
        Debug.Log("Add Object");
        for (int i=0; i<count; i++)
        {
            T obj = Instantiate(prefab);
            obj.gameObject.SetActive(false);
            objects.Enqueue(obj);
        }
    }

    // returns an object to the pool
    public void ReturnToPool(T objectToReturn)
    {
        Debug.Log("Return to pool");
        objectToReturn.gameObject.SetActive(false);
        objects.Enqueue(objectToReturn);
    }
}
