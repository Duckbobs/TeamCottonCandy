using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(_Map))]
public class MapCompiler : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("맵 데이터 추출"))
        {
            _Map map = (_Map)target;
            map.Generate();
        }
    }
}
