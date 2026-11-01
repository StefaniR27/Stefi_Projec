
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform spawnPoint;

    private bool hasSpawned = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;

        if (hasSpawned) return;

        Instantiate(
            platformPrefab,
            spawnPoint.position,
            Quaternion.identity
        );

        hasSpawned = true;
    }
}
