using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPath : MonoBehaviour
{
    public float radius = 1f;
    public float distanceFromBorder = 1f;
    public Vector2 pathScale = Vector2.one;

    public Vector2 Evaluate(float evalPoint) {
        // get point in 0-1 range
        float point = evalPoint % 1;
        radius = Mathf.Clamp(radius, 0, GetMaxRadius());

        float degrees = 360f * point;
        Vector2 pos = Vector2.right.Rotate(degrees) * radius;
        pos = Vector2.Scale(pos, pathScale);
        
        // clamp the point to stay within the camera bounds
        Vector2 bounds = GetCameraBounds();
        pos.x = Mathf.Clamp(pos.x, -bounds.x, bounds.x);
        pos.y = Mathf.Clamp(pos.y, -bounds.y, bounds.y);

        // add camera position so the point is always within the camera (assuming no camera rotation)
        pos.x += Camera.main.transform.position.x;
        pos.y += Camera.main.transform.position.y;

        return pos;
    }

    private Vector2 GetCameraBounds() {
        Camera mainCam = Camera.main;
        float aspect = (float)Screen.width / Screen.height;

        float height = mainCam.orthographicSize;
        float width = aspect * height;

        Vector2 bounds = new Vector2(width - distanceFromBorder, height - distanceFromBorder);
        bounds += new Vector2(mainCam.transform.position.x, mainCam.transform.position.y);
        return bounds;
    }

    private float GetMaxRadius() {
        float aspect = (float)Screen.width / Screen.height;
        float height = Camera.main.orthographicSize;
        float width = height * aspect;

        return new Vector2(width, height).magnitude;
    }

    private void OnDrawGizmosSelected() {
        float points = 50;
        for (int i = 0; i < points; i++) {
            Vector2 pointPos = Evaluate(i / points);
            Vector2 prevPoint = Evaluate((i-1)/points);
            Gizmos.DrawLine(pointPos, prevPoint);
        }
    }

}
