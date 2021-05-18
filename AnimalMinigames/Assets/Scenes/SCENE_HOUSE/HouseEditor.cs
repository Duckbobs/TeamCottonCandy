using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HouseEditor : MonoBehaviour
{
    public static bool isEditorMode = false;
    // 편집oj
    public GameObject EditorOpener;
    // 확인 oj
    public GameObject Editor;
    public GameObject Tile;
    
    public Dictionary<int, Vector2> HouseObjectsPosition = new Dictionary<int, Vector2>();

    //slot01
    public GameObject[] slotPrefab;
    public void OpenEditor()
    {
        if (isEditorMode == false)
        {
            isEditorMode = true;
            Editor.SetActive(true);
            EditorOpener.SetActive(false);
            Tile.SetActive(true);
            SavePositions();
        }
    }
    public void DoApply()
    {
        // TODO // if 겹친 구조물이 없을 경우
        /*************************************/

        // 적용
        Editor.SetActive(false);
        EditorOpener.SetActive(true);
        Tile.SetActive(false);
        isEditorMode = false;
        /*************************************/
    }
    public void DoCancel()
    {
        Editor.SetActive(false);
        EditorOpener.SetActive(true);
        Tile.SetActive(false);
        isEditorMode = false;

        // 되돌리기
        LoadPositions();
    }
    void LoadPositions()
    {
        Transform[] objects = GetComponentsInChildren<Transform>();
        foreach (var obj in objects)
        {
            if (obj.tag.Equals("HouseObject"))
            {
                if (HouseObjectsPosition.ContainsKey(obj.GetInstanceID()))
                {
                    obj.transform.localPosition = HouseObjectsPosition[obj.GetInstanceID()];
                    HouseObjectsPosition.Remove(obj.GetInstanceID());
                }
            }
        }
        HouseObjectsPosition.Clear();
    }
    void SavePositions()
    {
        HouseObjectsPosition.Clear();
        Transform[] objects = GetComponentsInChildren<Transform>();
        foreach (var obj in objects)
        {
            if (obj.tag.Equals("HouseObject"))
            {
                HouseObjectsPosition.Add(obj.GetInstanceID(), obj.transform.localPosition);
            }
        }
    }

    public void SlotClick(int i)
    {
        Instantiate(slotPrefab[i], new Vector2(5.0f, 0.0f), Quaternion.identity);             
    }
}
