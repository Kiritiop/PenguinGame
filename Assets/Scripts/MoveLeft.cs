using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float destroyX = -15f;

    void Update()
    {
        if (GameManager.Instance == null) return;

        float currentSpeed = GameManager.Instance.GetCurrentSpeed();

        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
