using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float minPlayerDistance=12f, maxPlayerDistance=15f;
    [SerializeField] private Transform parentTransform;
    [SerializeField] private float spawnInterval = 5f;
    private float timePassed = 0f;
    [SerializeField] private float spawnIntervalMultiplier = 0.95f;
    [SerializeField] private List<SpawnObject> spawnList;
    private float chanceSum;

    private void Start()
    {
        chanceSum = 0;
        foreach (SpawnObject spawnObject in spawnList)
        {
            chanceSum += spawnObject.spawnChance;
        }
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed>=spawnInterval)
        {
            timePassed = 0f;
            SpawnRandom();
            spawnInterval *= spawnIntervalMultiplier;
        }
    }

    // spawns a random spawn object based on its chance
    public void SpawnRandom()
    {
        float randomNumber = UnityEngine.Random.Range(0f, chanceSum);
        float tempSum = 0f;

        foreach (SpawnObject spawnObject in spawnList)
        {
            tempSum += spawnObject.spawnChance;
            if (randomNumber<=tempSum)
            {
                Vector3 spawnLocation = new Vector3();
                spawnLocation.y = 0f;
                spawnLocation.x = (UnityEngine.Random.Range(0,2)==0 ? 1:-1) * UnityEngine.Random.Range(minPlayerDistance, maxPlayerDistance);
                spawnLocation.z = (UnityEngine.Random.Range(0,2)==0 ? 1:-1) * UnityEngine.Random.Range(minPlayerDistance, maxPlayerDistance);
                Instantiate(spawnObject.gameObject, spawnLocation, Quaternion.identity, parentTransform);
            }
        }
    }


    [System.Serializable]
    public struct SpawnObject
    {
        public GameObject gameObject;
        public float spawnChance;
    }
}
