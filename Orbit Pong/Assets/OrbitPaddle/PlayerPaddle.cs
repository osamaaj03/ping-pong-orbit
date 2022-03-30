using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{
    public float speed = 2f;

    public Transform paddle;
    public PlayerPath path;

    private float move;
    private float paddleWidth = 0.05f;

    private void Awake() {
        path = GetComponent<PlayerPath>();
    }

    private void Update() {
        MovePlayer();
    }

    private void MovePlayer() {
        float moveAxis = Input.GetAxis("Horizontal");
        move += moveAxis * Time.deltaTime * speed / path.radius;

        float halfWidth = paddleWidth / 2;
        Vector2 leftPos = path.Evaluate(move - halfWidth);
        Vector2 rightPos = path.Evaluate(move + halfWidth);
        Vector2 pos = 0.5f * (leftPos - rightPos) + rightPos;

        Vector2 upDir = (rightPos - leftPos).Rotate(90);

        if (paddle != null) {
            paddle.transform.position = pos;
            paddle.transform.up = upDir;
        }
        else {
            transform.position = pos;
            transform.transform.up = upDir;
        }
       
    }
}
