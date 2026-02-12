using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject[] fishPrefabs;
    public float spawnRate = 2f;
    public float minY = -4f;
    public float maxY = 4f;
    public float spawnX = 10f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnFish), 1f, spawnRate);
    }

    void SpawnFish()
    {
        int index = Random.Range(0, fishPrefabs.Length);
        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPos = new Vector3(spawnX, randomY, 0);
        Instantiate(fishPrefabs[index], spawnPos, Quaternion.identity);
    }
}
