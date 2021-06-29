using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneWindow : EditorWindow
{
    // ボタンの大きさ
    private readonly Vector2 buttonMinSize = new Vector2(100, 20);
    private readonly Vector2 buttonMaxSize = new Vector2(1000, 40);

    [MenuItem("U_Tool/SceneWindow")]

    static void ShowWindow()
    {
        // ウィンドウを表示！
        EditorWindow.GetWindow<SceneWindow>();
    }

    void OnGUI()
    {
        // レイアウトを整える
        GUIStyle buttonStyle = new GUIStyle("button") { fontSize = 16 };
        var layoutOptions = new GUILayoutOption[]
        {
            GUILayout.MinWidth(buttonMinSize.x),
            GUILayout.MinHeight(buttonMinSize.y),
            GUILayout.MaxWidth(buttonMaxSize.x),
            GUILayout.MaxHeight(buttonMaxSize.y)
        };

        // ボタンを作る
        if (GUILayout.Button("HomeScene", buttonStyle, layoutOptions))
        {
            // シーンを保存するか確認
            if (!EditorSceneManager.SaveModifiedScenesIfUserWantsTo(new Scene[] { SceneManager.GetActiveScene() })) return;
            // シーンを開く
            OpenScene("HomeScene");
        }

        if (GUILayout.Button("World_School", buttonStyle, layoutOptions))
        {
            if (!EditorSceneManager.SaveModifiedScenesIfUserWantsTo(new Scene[] { SceneManager.GetActiveScene() })) return;
            OpenScene("World_School");
        }

        if (GUILayout.Button("SoccerScene", buttonStyle, layoutOptions))
        {
            if (!EditorSceneManager.SaveModifiedScenesIfUserWantsTo(new Scene[] { SceneManager.GetActiveScene() })) return;
            OpenScene("SoccerScene");
        }


    }

    // シーンを開ける関数
    private void OpenScene(string sceneName)
    {
        var sceneAssets = AssetDatabase.FindAssets("t:SceneAsset")
            .Select(AssetDatabase.GUIDToAssetPath)
            .Select(path => AssetDatabase.LoadAssetAtPath(path, typeof(SceneAsset)))
            .Where(obj => obj != null)
            .Select(obj => (SceneAsset)obj)
            .Where(asset => asset.name == sceneName);
        var scenePath = AssetDatabase.GetAssetPath(sceneAssets.First());
        EditorSceneManager.OpenScene(scenePath);
    }
}
