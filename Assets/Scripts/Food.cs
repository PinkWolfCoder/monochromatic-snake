using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SnakeHead"))
        {
            GameManager.Instance.Score++;
            GameManager.Instance.SpawnFood();
            Snake.Instance.AddTail();
            Destroy(gameObject);
        }
    }
}