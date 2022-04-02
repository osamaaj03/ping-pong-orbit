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

    public void DisableGravity()
    {
        rb.gravityScale = 0;
    }

}
