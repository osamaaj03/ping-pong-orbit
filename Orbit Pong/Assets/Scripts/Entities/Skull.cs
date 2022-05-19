using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pong.Entities;

public class Skull : Enemy
{
    [SerializeField] float RotateSpeed = 5f;
    [SerializeField] float Radius = 0.1f;

    private Vector2 _centre;
    private float _angle;
    // Start is called before the first frame update
    void Start()
    {
        _centre = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;
    }
}
