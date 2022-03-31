using UnityEngine;
using System;
using Random = UnityEngine.Random;
public class ball : MonoBehaviour
{
    public Vector2 speed;
    public float speedMultplier = 1;
    public AudioClip hitSound;

    private AudioSource audioSource;
    private admin center;
    private colors randomColor;
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        center = FindObjectOfType<admin>();
    }

    void FixedUpdate () {
        rb.velocity = speed * Time.deltaTime * speedMultplier;
    }

    void OnCollisionEnter2D (Collision2D collision)   {
        if(collision.gameObject.CompareTag("Hit")   /* && (int) FindObjectOfType<paddleControll>().currentColor == (int) randomColor*/) {
            speed = collision.transform.up;
            PlayHit();
            if (collision.gameObject.layer == LayerMask.NameToLayer("shield")) {
                Destroy(collision.gameObject, 1);
                center.health--;
            }
        }
    }

    void PlayHit() {
        audioSource.pitch = Random.Range(0.5f, 1.0f);
        audioSource.PlayOneShot(hitSound);
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
