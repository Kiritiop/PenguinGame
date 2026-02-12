using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float spawnRate = 3f;
    public float minY = -4f;
    public float maxY = 4f;
    public float spawnX = 10f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 2f, spawnRate);
    }

    void SpawnEnemy()
    {
        int index = Random.Range(0, enemyPrefabs.Length);
        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPos = new Vector3(spawnX, randomY, 0);
        Instantiate(enemyPrefabs[index], spawnPos, Quaternion.identity);
    }
}
