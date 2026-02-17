using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject[] fishPrefabs;

    public float startSpawnRate = 2f;        // seconds between spawns at start
    public float minSpawnRate = 0.5f;        // fastest allowed spawn rate
    public float spawnAcceleration = 0.05f;  // how fast spawn rate decreases

    public float minY = -4f;
    public float maxY = 4f;
    public float spawnX = 10f;

    private float timer;
    private float currentSpawnRate;

    void Start()
    {
        currentSpawnRate = startSpawnRate;
    }

    void Update()
    {
        if (GameManager.Instance == null) return;

        // Difficulty scaling
        currentSpawnRate = Mathf.Max(
            minSpawnRate,
            startSpawnRate - (Time.timeSinceLevelLoad * spawnAcceleration)
        );

        timer += Time.deltaTime;

        if (timer >= currentSpawnRate)
        {
            SpawnFish();
            timer = 0f;
        }
    }

    void SpawnFish()
    {
        int index = Random.Range(0, fishPrefabs.Length);
        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPos = new Vector3(spawnX, randomY, 0);

        Instantiate(fishPrefabs[index], spawnPos, Quaternion.identity);
    }
}
