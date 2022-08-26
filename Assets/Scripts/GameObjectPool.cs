using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private Queue<GameObject> objects = new Queue<GameObject>();


    // returns an object from the pool (Instantiates it if neccessary)
    public GameObject Get(out bool newObjectInstantiated)
    {
        newObjectInstantiated = false;
        if (objects.Count==0)
        {
            newObjectInstantiated = true;
            AddObjects(1);
        }
        return objects.Dequeue();
    }

    // instantiates new objects and adds them to the pool
    private void AddObjects(int count)
    {
        for (int i=0; i<count; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.gameObject.SetActive(false);
            objects.Enqueue(obj);
        }
    }

    // returns an object to the pool
    public void ReturnToPool(GameObject objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        objects.Enqueue(objectToReturn);
    }
}
