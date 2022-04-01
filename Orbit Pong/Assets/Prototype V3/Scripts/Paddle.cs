using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float hitForce;
    public AudioClip hitSound;
    private Rigidbody2D rb;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ball")
        {
            PlayHit();
            Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector3 hitPoint = collision.contacts[0].point;
            
            Vector3 difference = transform.position - hitPoint;
            float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            float width = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(transform.up, ballRb.velocity);
            float bounceAngle = (angle / width) * 75;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -75, 75);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, transform.forward);
            ballRb.velocity = rotation * transform.up  * ballRb.velocity.magnitude;
        }
    }
    void PlayHit() {
        audioSource.pitch = Random.Range(0.5f, 1.0f);
        audioSource.PlayOneShot(hitSound);
    }
}
