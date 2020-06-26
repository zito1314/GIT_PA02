using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] prefabs;
    public float minTime, maxTime;
    public int numberOfSpawns = 2;

    private float timer = 0f;
    private int lastSpawnPointIndex = -1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0f)
        {
            SpawnItems();
            ResetTimer();
        }
        timer -= Time.deltaTime;
    }

    private void SpawnItems()
    {
        for (int i = 0; i < numberOfSpawns; i++)
        {
            Transform spawnPoint = GetNextSpawnPoint();
            GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];
            Instantiate(prefab, spawnPoint);
        }
    }

    private Transform GetNextSpawnPoint()
    {
        // We want a random index from the error, but not the same as last time.
        // So we at least more one index further and stop one index before the last.
        // The % operator loops back to the beginning of zero, if the index overshoots the array length.
        int index = (lastSpawnPointIndex + Random.Range(1, spawnPoints.Length - 1)) % spawnPoints.Length;
        lastSpawnPointIndex = index;
        return spawnPoints[index];
    }

    private void ResetTimer()
    {
        timer = Random.Range(minTime, maxTime);
    }
}




