using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBarrier : MonoBehaviour
{
    public bool invertRotation;
    [Tooltip ("degrees per second")]public float turnSpeed = 90;
    public Transform paddleParent;

    private void Awake() {
        if (paddleParent == null) paddleParent = transform;
    }

    private void Update() {
        ControlPaddleRotation();
    }

    private void ControlPaddleRotation(){
        float rotateAmount = Input.GetAxis("Horizontal");
        rotateAmount *= turnSpeed * Time.deltaTime;

        if (invertRotation) rotateAmount = -rotateAmount;

        // a positive rotateAmount is counter-clockwise. negative is clockwise
        transform.Rotate(Vector3.forward, rotateAmount);
    }
}
