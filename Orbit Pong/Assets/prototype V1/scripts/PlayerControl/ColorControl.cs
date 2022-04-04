using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Colors {
    red,
    green,
    blue
}
public class ColorControl : MonoBehaviour
{
    public GameObject[] paddles;
    private Colors currentColor;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            currentColor = Colors.red;
            changeColor();
        }
        if(Input.GetKeyDown(KeyCode.G)) {
            currentColor = Colors.green;
            changeColor();
        }
        if(Input.GetKeyDown(KeyCode.B)) {
            currentColor = Colors.blue;
            changeColor();
        }
    }

    void changeColor() {
        foreach(GameObject paddle in paddles) {
            switch (currentColor)
            {
                case Colors.red: {
                    paddle.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
                    break;
                }
                case Colors.green: {
                    paddle.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                    break;
                }
                case Colors.blue: {
                    paddle.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1);
                    break;
                }
            }  
        }
    }
}