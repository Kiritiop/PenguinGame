using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    public float startSpawnRate = 3f;
    public float minSpawnRate = 0.7f;
    public float spawnAcceleration = 0.03f;

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

        currentSpawnRate = Mathf.Max(minSpawnRate, startSpawnRate - (Time.timeSinceLevelLoad * spawnAcceleration));

        timer += Time.deltaTime;

        if (timer >= currentSpawnRate)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        int index = Random.Range(0, enemyPrefabs.Length);
        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPos = new Vector3(spawnX, randomY, 0);

        Instantiate(enemyPrefabs[index], spawnPos, Quaternion.identity);
    }
}
