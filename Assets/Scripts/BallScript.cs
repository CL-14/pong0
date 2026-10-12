using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 30f;
    private Rigidbody2D rb;

    public static int p1Score = 0;
    public static int p2Score = 0;
    public static int maxScore = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.right * speed;
        p1Score = 0;
        p2Score = 0;
    }

    void Update()
    {
        if (p1Score >= maxScore || p2Score >= maxScore)
        {
            transform.position = Vector2.zero;
            rb.linearVelocity = Vector2.zero;
        }
    }

    float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Raqueta izquierda
        if (col.gameObject.name == "RacketLeft")
        {
            float y = HitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 dir = new Vector2(1, y).normalized;
            rb.linearVelocity = dir * speed;
        }

        // Raqueta derecha
        if (col.gameObject.name == "RacketRight")
        {
            float y = HitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 dir = new Vector2(-1, y).normalized;
            rb.linearVelocity = dir * speed;
        }

        if (col.gameObject.name == "WallRight")
        {
            transform.position = new Vector2(-5, 0);
            rb.linearVelocity = new Vector2(-1, 0).normalized * speed;
            p1Score++;
            Debug.Log("Player one score is: " + p1Score);
        }

        if (col.gameObject.name == "WallLeft")
        {
            transform.position = new Vector2(5, 0);
            rb.linearVelocity = new Vector2(1, 0).normalized * speed;
            p2Score++;
            Debug.Log("Player two score is: " + p2Score);
        }
    }
}
