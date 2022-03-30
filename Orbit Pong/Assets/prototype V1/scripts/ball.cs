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

    enum colors {
        red,
        green,
        blue
    }

    void Start() {
        audioSource = GetComponent<AudioSource>();
        center = FindObjectOfType<admin>();
    }

    void Update () {
        changeColor();
        transform.position += new Vector3(speed.x, speed.y) * Time.deltaTime * speedMultplier;
    }

    void OnTriggerEnter2D (Collider2D other)   {
        if(other.gameObject.name == "paddle V" && (int) FindObjectOfType<paddleControll>().currentColor == (int) randomColor) {
            speed.x = -speed.x;
            PlayHit();
        }
        if(other.gameObject.name == "paddle H" && (int) FindObjectOfType<paddleControll>().currentColor == (int) randomColor) {
            speed.y = -speed.y;
            PlayHit();
        }
        Array values = Enum.GetValues(typeof(colors));
        randomColor = (colors)values.GetValue(Random.Range(0, values.Length));
    }

    void PlayHit() {
        audioSource.pitch = Random.Range(0.5f, 1.0f);
        audioSource.PlayOneShot(hitSound);
    }
    
    void changeColor() {
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
    }
}
