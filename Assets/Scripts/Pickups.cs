using UnityEngine;
using UnityEngine.UI;

public class Pickups : MonoBehaviour
{
    public Image[] keysUI;
    public Sprite fullKey;

    private int keyCount = 0;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Key"))
        {
            Destroy(col.gameObject);

            PlayerHealth player = GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.AddKey();
            }

            if (keyCount < keysUI.Length)
            {
                keysUI[keyCount].sprite = fullKey;
                keyCount++;
            }

            Debug.Log("Key collected!");
        }
    }
}