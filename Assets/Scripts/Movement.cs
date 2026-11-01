
using UnityEngine;

public class Movement : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;

    public Animator animator;

    float horizontal;
    float vertical;

    GameManager gm;

    [SerializeField]
    float speed;

    Rigidbody2D rb;

    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();

        speed = 3;

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (gm != null && gm.gameEnded)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Vector2 move = Vector2.zero;

        if (Input.GetKey(leftKey))
            move.x = -1;

        if (Input.GetKey(rightKey))
            move.x = 1;

        if (Input.GetKey(upKey))
            move.y = 1;

        if (Input.GetKey(downKey))
            move.y = -1;

        move = move.normalized;

        horizontal = move.x;
        vertical = move.y;

        animator.SetBool("isWalking", move != Vector2.zero);
    }


    void FixedUpdate()
    {
        if (gm != null && gm.gameEnded)
            return;

        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

}
