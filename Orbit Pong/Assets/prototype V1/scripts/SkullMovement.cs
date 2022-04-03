using UnityEngine;

public class SkullMovement : MonoBehaviour
{
    public float speed;
    public float range;
    public bool test;
    private Rigidbody2D rb;
    private Vector2 dir;
    Vector3 start;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        start = transform.position;
        if (test)
            dir = Vector2.right;
        else {
            float x = Random.Range(-1.0f, 1.0f);
            float y;
            if(x > 0)
                y = 1 - x;
            else
                y = x - 1;
            dir = new Vector2 (x, y);
            Debug.Log(dir);
        }
    }

    void FixedUpdate()
    {
        float distance = Vector2.Distance(start, transform.position);
        if (distance < range/1.05f) {
            rb.velocity = Mathf.Sqrt(range - distance) * dir * Time.deltaTime * speed;
        } else {
            rb.velocity = dir * Time.deltaTime * speed * 4;
        }
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "wall") {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
