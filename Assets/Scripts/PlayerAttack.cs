using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 5f;
    public LayerMask EnemyLayer;
    public KeyCode attackKey;
    void Update()
    {
        if (Input.GetKeyDown(attackKey))
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider2D enemy = Physics2D.OverlapCircle(transform.position, attackRange, EnemyLayer);

        if (enemy != null)
        {
            EnemyHealth eh = enemy.GetComponentInParent<EnemyHealth>();

            if (eh != null)
            {
                eh.TakeDamage(1);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(1);
        }
    }
}