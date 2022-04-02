using UnityEngine;
using System;
using Random = UnityEngine.Random;
public class BallV2 : MonoBehaviour
{
    private colors randomColor;
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.down * 200);
    }

    void Update() {
        Debug.DrawRay(transform.position, rb.velocity);
    }

    void OnCollisionEnter2D (Collision2D collision)   {
        /*if (collision.gameObject.layer == LayerMask.NameToLayer("shield")) {
                Destroy(collision.gameObject, 1);
        }*/
    }
    
    /*void changeColor() {
        Array values = Enum.GetValues(typeof(colors));
        randomColor = (colors)values.GetValue(Random.Range(0, values.Length));
        switch (randomColor)
        {
            case colors.red: {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
                break;
            }
            case colors.green: {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                break;
            }
            case colors.blue: {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1);
                break;
            }
        }
    }*/
}
