using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PaddleBarrier))]
public class PaddleBarrierInspector : Editor
{
    SerializedProperty paddleParent;

    float radius;
    Vector2 paddleSize;

    private void OnEnable() {
        paddleParent = serializedObject.FindProperty("paddleParent");

        // get the first paddle and set radius/paddleSize because they don't get saved
        Transform parent = paddleParent.objectReferenceValue as Transform;

        if (parent != null && parent.childCount > 0) {
            radius = parent.GetChild(0).localPosition.magnitude;
            paddleSize = parent.GetChild(0).localScale;
        }
    }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        GUILayout.Space(15f);

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

        GUILayout.Space(15f);

        radius = EditorGUILayout.FloatField(new GUIContent("Distance From Center"), radius);
        paddleSize = EditorGUILayout.Vector2Field(new GUIContent("Paddle Size", "Sets paddle scale to (x,y,1)"), paddleSize);

        // adding space to avoid misclicking the buttons
        GUILayout.Space(20f);

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Auto Position Paddles")) PositionPaddles();
        if (GUILayout.Button("Resize Paddles")) ResizePaddles();
        EditorGUILayout.EndHorizontal();
    }

    private void PositionPaddles() {
        Transform parent = paddleParent.objectReferenceValue as Transform;
        if (parent == null || parent.childCount == 0) return;

        float angle = (float)360f / parent.childCount;
        for (int i = 0; i < parent.childCount; i++) {
            float radian = angle * Mathf.Deg2Rad * i;
            parent.GetChild(i).localPosition = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0) * radius;
            parent.GetChild(i).localRotation = Quaternion.Euler(0, 0, angle * i);
        }
    }

    private void ResizePaddles() {
        Transform parent = paddleParent.objectReferenceValue as Transform;
        if (parent == null) return;

        for (int i = 0; i < parent.childCount; i++) {
            parent.GetChild(i).localScale = new Vector3(paddleSize.x, paddleSize.y, 1);
        }
    }
}
