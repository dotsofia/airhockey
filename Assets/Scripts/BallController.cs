using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D _rb2d;

    private AudioSource source;


    void GoBall()
    {
        int randomSign = Random.Range(0, 2) * 2 - 1;
        _rb2d.AddForce(new Vector2(20 * randomSign, -15));
    }

    void ResetBall()
    {
        _rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();

        _rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            source.Play();

            Vector2 vel;
            vel.x = (_rb2d.velocity.x / 2) + (collision.collider.attachedRigidbody.velocity.x / 3);
            vel.y = (_rb2d.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
            _rb2d.velocity = vel;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
