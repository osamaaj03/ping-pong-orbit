using UnityEngine;

    public enum colors {
        red,
        green,
        blue
    }

public class PaddleControllV2 : MonoBehaviour
{
    
    [HideInInspector]
    public colors currentColor;
    public Camera camera2D;
    public LayerMask[] layerMask;
    public GameObject[] paddle;
    public float speedLimit;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5;

        Vector3 objectPos = camera2D.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        Quaternion lookAt = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookAt, speedLimit * Time.deltaTime);
        Debug.DrawRay(transform.position, transform.right * 24);

        for (int i = 0; i < paddle.Length; i++) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 24, layerMask[i]);
            if (hit.collider != null)
            {
                paddle[i].transform.position = new Vector3 (hit.point.x, hit.point.y);
            }

        }
        //color switching
        /*if(Input.GetKeyDown(KeyCode.R)) {
            currentColor = colors.red;
            changeColor();
        }
        if(Input.GetKeyDown(KeyCode.G)) {
            currentColor = colors.green;
            changeColor();
        }
        if(Input.GetKeyDown(KeyCode.B)) {
            currentColor = colors.blue;
            changeColor();
        }      */ 
    }
    /*void changeColor() {
        switch (currentColor)
        {
            case colors.red: {
                paddle.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
                break;
            }
            case colors.green: {
                paddle.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                break;
            }
            case colors.blue: {
                paddle.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1);
                break;
            }
        }
    }*/
}
