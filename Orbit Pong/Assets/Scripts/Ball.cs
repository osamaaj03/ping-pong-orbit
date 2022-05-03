using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ball : MonoBehaviour
{

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        // reset the ball for testing
        if (Input.GetKeyDown(KeyCode.R)) {
            rb.position = Vector3.zero;
            rb.velocity = Vector3.zero;
            rb.gravityScale = 1;
        }
    }

    public void DisableGravity()
    {
        rb.gravityScale = 0;
    }

}
