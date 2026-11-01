using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 2f;
    public float chaseRange = 5f;
    public float attackRange = 1.2f;

    public float attackCooldown = 1.5f;
    private float attackTimer;

    private Transform target;
    private PlayerHealth targetHealth;

    private GameObject[] players;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update()
    {
        FindClosestPlayer();

        if (target == null) return;

        float distance = Vector2.Distance(transform.position, target.position);

        if (distance < chaseRange && distance > attackRange)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                target.position,
                speed * Time.deltaTime
            );
        }

        if (distance <= attackRange)
        {
            Attack();
        }

        attackTimer -= Time.deltaTime;
    }

    void FindClosestPlayer()
    {
        float minDistance = Mathf.Infinity;
        target = null;
        targetHealth = null;

        foreach (GameObject p in players)
        {
            if (p == null) continue;

            float dist = Vector2.Distance(transform.position, p.transform.position);

            if (dist < minDistance)
            {
                minDistance = dist;
                target = p.transform;
                targetHealth = p.GetComponent<PlayerHealth>();
            }
        }
    }

    void Attack()
    {
        if (attackTimer > 0) return;

        if (targetHealth != null)
        {
            targetHealth.TakeDamage(1);
        }

        attackTimer = attackCooldown;
    }
}