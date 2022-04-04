using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    public float speed;
    public float Range;
    private Rigidbody2D rb;
    private Vector2 direction;
    private Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 startPos = transform.position; 
        float x = Random.Range(-1.0f, 1.0f);
        float y;
        if(x > 0)
            y = 1 - x;
        else
            y = - x - 1;
        direction = new Vector2(x, y);
        Debug.Log(direction);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector2.Distance(startPos, direction * Range);
        if(distance > 0.001)
            rb.velocity = Mathf.Sqrt(distance) * direction * speed * Time.deltaTime;
        else
            rb.velocity = direction * speed * 4 * Time.deltaTime;
    }
}
