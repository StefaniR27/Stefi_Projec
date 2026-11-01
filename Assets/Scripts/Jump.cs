
using UnityEngine;

public class Jump : MonoBehaviour
{
    public KeyCode jumpKey;

    public float firstJumpForce = 9f;
    public float secondJumpForce = 6f;

    public Animator animator;

    private Rigidbody2D rb;
    private bool isOnGround;
    private int jumpsRemaining = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(jumpKey) && jumpsRemaining > 0)
        {
            if (jumpsRemaining == 2 && isOnGround)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
                rb.AddForce(Vector2.up * firstJumpForce, ForceMode2D.Impulse);
            }
            else if (jumpsRemaining == 1 && !isOnGround)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
                rb.AddForce(Vector2.up * secondJumpForce, ForceMode2D.Impulse);
            }
            else
            {
                return;
            }

            jumpsRemaining--;

            if (animator != null)
                animator.SetTrigger("jump");

            isOnGround = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            // Само сблъсък отгоре се брои за приземяване.
            if (contact.normal.y > 0.5f)
            {
                isOnGround = true;
                jumpsRemaining = 2;
                return;
            }
        }
    }
}
