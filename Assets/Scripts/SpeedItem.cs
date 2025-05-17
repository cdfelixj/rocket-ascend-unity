using UnityEngine;

public class SpeedItem : MonoBehaviour
{
    public float speedMultiplier = 1.5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.StartSpeedBoost(speedMultiplier);
                Destroy(gameObject);
            }
        }
    }
}
