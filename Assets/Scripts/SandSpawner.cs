using UnityEngine;

public class SandSpawner : MonoBehaviour
{
    public GameObject sandPrefab;
    public int initialTiles = 5;
    public float tileWidth = 20f;

    private float lastSpawnX = 0f;

    void Start()
    {
        for (int i = 0; i < initialTiles; i++)
        {
            SpawnTile();
        }
    }

    void SpawnTile()
    {
        Instantiate(sandPrefab, new Vector3(lastSpawnX, -4f, 0), Quaternion.identity);
        lastSpawnX += tileWidth;
    }

    void Update()
    {
        if (Camera.main.transform.position.x + 20 > lastSpawnX)
        {
            SpawnTile();
        }
    }
}
