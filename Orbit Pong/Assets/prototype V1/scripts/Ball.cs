using UnityEngine;
using System;
using Random = UnityEngine.Random;

public enum Colors {
        red,
        green,
        blue
 }

public class Ball : MonoBehaviour
{
    public Vector2 speed;
    public float speedMultplier = 1;
    public AudioClip hitSound;

    private AudioSource audioSource;
    private Admin center;
    private Colors randomColor;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        center = FindObjectOfType<Admin>();
    }

    void Update () {
        ChangeColor();
        transform.position += new Vector3(speed.x, speed.y) * Time.deltaTime * speedMultplier;
    }

    void OnTriggerEnter2D (Collider2D other)   {
        if(other.gameObject.name == "Paddle V" && (int) FindObjectOfType<PaddleControl>().currentColor == (int) randomColor) {
            speed.x = -speed.x;
            PlayHit();
        }
        if(other.gameObject.name == "Paddle H" && (int) FindObjectOfType<PaddleControl>().currentColor == (int) randomColor) {
            speed.y = -speed.y;
            PlayHit();
        }
        Array values = Enum.GetValues(typeof(Colors));
        randomColor = (Colors)values.GetValue(Random.Range(0, values.Length));
    }

    void PlayHit() {
        audioSource.pitch = Random.Range(0.5f, 1.0f);
        audioSource.PlayOneShot(hitSound);
    }
    
    void ChangeColor() {
        switch (randomColor)
        {
            case Colors.red: {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
                break;
            }
            case Colors.green: {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                break;
            }
            case Colors.blue: {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1);
                break;
            }
        }
    }
}
