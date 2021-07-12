using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(BaseballManager))]
public class GameStartEditorScript : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("何？Quest2が無いだって？しょーがないなぁ･･･ボクを押しなよ。ゲームスタートしてあげるからさ。", MessageType.Warning);

        BaseballManager baseballManager = (BaseballManager)target;
        if (GUILayout.Button("バッティングセンターを起動したいんだろう？"))
        {
            baseballManager.GameStart();
        }
    }
}
