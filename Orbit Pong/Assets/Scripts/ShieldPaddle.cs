using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPaddle : MonoBehaviour
{
    int hitCount = 0;

    //Provide the list of sprites for the state of the shield (For example: empty, half, full power)
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
            // Start the game with gravity enabled so the ball falls towards the paddle, 
            // but once it connects with a paddle, disable gravity so it has a more straight trajectory
            other.gameObject.GetComponent<Ball>().DisableGravity();

            HandleShieldDeflect();
        }
    }

    void HandleShieldDeflect()
    {
        hitCount++;

        // if the shield has been hit enough times by the ball, activate its power.
        if (hitCount >= activatorSprites.Count)
        {
            // Placeholder for the shield being powered up / activated
            shieldSprite.color = Color.green;
        }
        else
        {
            shieldSprite.sprite = activatorSprites[hitCount - 1];
        }
    }
}