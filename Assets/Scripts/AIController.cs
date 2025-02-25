using UnityEngine;

public class AIController : MonoBehaviour
{
    public Transform puck;
    public float speed = 5f;
    public float activationDistance = 1f; // Distance at which AI moves toward puck
    public float stopDistance = 0.5f;

    private Rigidbody2D rb;
    private Vector2 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position; // Record initial position
    }

    void FixedUpdate()
    {
        if (puck == null) return;

        float puckDistance = Vector2.Distance(transform.position, puck.position);

        Vector2 targetPosition = puckDistance < activationDistance ? (Vector2)puck.position : startPosition;

        MoveTowards(targetPosition);
    }

    void MoveTowards(Vector2 target)
    {
        float distance = Vector2.Distance(transform.position, target);

        if (distance > stopDistance)
        {
            Vector2 direction = (target - (Vector2)transform.position).normalized;
            rb.velocity = direction * speed;
        }
        else
        {
            rb.velocity = Vector2.zero; // Stop when near target
        }
    }
}
