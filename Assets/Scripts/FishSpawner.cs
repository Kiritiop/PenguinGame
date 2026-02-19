using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject[] fishPrefabs;

    public float startSpawnRate = 2f;
    public float minSpawnRate = 0.5f;
    public float spawnAcceleration = 0.05f;

    public Transform sandLevel;
    public float minHeightAboveSand = 0f;
    public float maxHeightAboveSand = 2f;
    public float spawnX = 10f;

    public LayerMask enemyLayer;

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
            SpawnFish();
            timer = 0f;
        }
    }

    void SpawnFish()
    {
        int index = Random.Range(0, fishPrefabs.Length);

        float randomHeight = Random.Range(minHeightAboveSand, maxHeightAboveSand);
        float spawnY = sandLevel.position.y + randomHeight;

        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);
        Collider2D hit = Physics2D.OverlapCircle(spawnPos, 0.7f, enemyLayer);

        if (hit == null)
        {
            Instantiate(fishPrefabs[index], spawnPos, Quaternion.identity);
        }
    }
}
