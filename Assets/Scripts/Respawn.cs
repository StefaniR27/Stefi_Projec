using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector3 respawnPoint2;
    public GameObject DeathZone;

    private PlayerHealth health;

    void Start()
    {
        respawnPoint2 = transform.position;

        health = FindFirstObjectByType<PlayerHealth>();
    }

    void FixedUpdate()
    {
        if (DeathZone != null)
        {
            DeathZone.transform.position =
                new Vector2(transform.position.x, DeathZone.transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            transform.position = respawnPoint2;

            PlayerHealth player = GetComponent<PlayerHealth>();

            if (player != null)
            {
                player.TakeDamage(1);
            }
        }
    }

}