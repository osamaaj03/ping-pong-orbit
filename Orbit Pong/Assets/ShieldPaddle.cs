using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPaddle : MonoBehaviour
{
    int hitCount = 0;
    [SerializeField] List<Sprite> activatorSprites;
    SpriteRenderer shieldSprite;

    void Start()
    {
        shieldSprite = GetComponent<SpriteRenderer>();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {

            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;

            hitCount++;

            if (hitCount >= activatorSprites.Count)
            {
                shieldSprite.color = Color.green;
            }
            else
            {
                shieldSprite.sprite = activatorSprites[hitCount - 1];
            }
        }
    }
}