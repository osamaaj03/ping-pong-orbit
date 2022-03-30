using UnityEngine;
using System.Collections.Generic;

public class PaddleControl : MonoBehaviour
{
    
    [HideInInspector]
    public Colors currentColor;
    public Camera camera2D;
    public LayerMask layerMaskFoor;
    public LayerMask layerMaskwall;
    public GameObject paddleH;
    public GameObject paddleV;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = camera2D.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        RaycastHit2D hitFloor = Physics2D.Raycast(transform.position, transform.right, 20, layerMaskFoor);
        Debug.DrawRay(transform.position, transform.right*20);
        RaycastHit2D hitWall = Physics2D.Raycast(transform.position, transform.right, 20, layerMaskwall);
        if (hitFloor.collider != null)
        {
            if (hitFloor.point.y < 0) {
                paddleH.transform.position = new Vector3 (hitFloor.point.x, -4.8f);
            } else {
                paddleH.transform.position = new Vector3 (hitFloor.point.x, 4.8f);
            }
        }
        if (hitWall.collider != null)
        {
            if (hitWall.point.x < 0) {
                paddleV.transform.position = new Vector3 (-8.6925f, hitWall.point.y);
            } else {
                paddleV.transform.position = new Vector3 (8.6925f, hitWall.point.y);
            }
        }
        //color switching
        if(Input.GetKeyDown(KeyCode.R)) {
            ChangeColor();
            currentColor = Colors.red;
        }
        if(Input.GetKeyDown(KeyCode.G)) {
            ChangeColor();
            currentColor = Colors.green;
        }
        if(Input.GetKeyDown(KeyCode.B)) {
            ChangeColor();
            currentColor = Colors.blue;
        }       
    }
    void ChangeColor() {
        switch (currentColor)
        {
            case Colors.red: {
                paddleH.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
                paddleV.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
                break;
            }
            case Colors.green: {
                paddleH.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                paddleV.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                break;
            }
            case Colors.blue: {
                paddleH.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1);
                paddleV.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1);
                break;
            }
        }
    }
}