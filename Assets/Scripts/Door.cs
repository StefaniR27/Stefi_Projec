using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite closedSprite;
    public Sprite openSprite;

    public GameManager gm;

    public PlayerHealth player1;
    public PlayerHealth player2;

    private SpriteRenderer sr;
    private bool isOpen = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (sr != null && closedSprite != null)
            sr.sprite = closedSprite;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth player = other.GetComponentInParent<PlayerHealth>();

        if (player == null) return;

        if (!isOpen && player.keys >= player.requiredKeys)
        {
            OpenDoor(player);
        }
    }

    void OpenDoor(PlayerHealth winner)
    {
        isOpen = true;

        if (sr != null && openSprite != null)
            sr.sprite = openSprite;

        if (gm != null)
        { 
            gm.PlayerDied(winner == player1 ? player2 : player1);
        }
    }
}