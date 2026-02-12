using UnityEngine;

public class Fish : MonoBehaviour
{
    public int points = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(points);
            Destroy(gameObject);
        }
    }
}
