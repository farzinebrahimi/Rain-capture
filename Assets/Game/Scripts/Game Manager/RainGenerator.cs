using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class RainGenerator : MonoBehaviour
{
    [SerializeField] private GameObject raindropPrefab; 
    [SerializeField] private float spawnInterval = 1f;  
    [SerializeField] private float spawnRangeX = 10f;   
    [SerializeField] private float spawnY = 10f;

    private void Start()
    {
        StartCoroutine(SpawnRain());
    }

    IEnumerator  SpawnRain()
    {
        while (true)
        {
            float randX = Random.Range(-spawnRangeX, spawnRangeX);
            Vector3 spawnPosition = new Vector3(randX, spawnY, 0f);
            Instantiate(raindropPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
