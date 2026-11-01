using UnityEngine;

public class spring_out : MonoBehaviour
{
    [SerializeField] float jumpForce = 20f;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;

        Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
        if (rb == null) return;

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}