using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//--Stolen-- Inspired by https://catlikecoding.com/unity/tutorials/curves-and-splines/


[CustomEditor(typeof(EnemyPath))]
public class PathEdit : Editor
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnSceneGUI()
    {
        EnemyPath path = (EnemyPath)target;


        for (int i = 0; i < path.nodes.Length; i++)
        {
            EditorGUI.BeginChangeCheck();

            Vector3 newTargetPosition = Handles.PositionHandle(path.nodes[i], Quaternion.identity);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(path, "Change path position");
                path.nodes[i] = newTargetPosition;
            }
        }
    }
}
