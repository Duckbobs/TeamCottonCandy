using System.Collections;
using System.Collections.Generic;

using System.IO;
using System.Text;

using UnityEngine;
[ExecuteInEditMode]
public class _Map : MonoBehaviour
{
    struct MapStruct
    {
        public Vector3 position;
        public string sprite;
        public string tag;
    };

    public string mapName;
    public void Update()
    {
        transform.localPosition = RoundVec3(transform.localPosition, 0.5f);
        gameObject.name = "Map_"+ mapName;
        gameObject.tag = "Untagged";
    }

    Vector3 RoundVec3(Vector3 vector, float gridSize) {
        Vector3 result = new Vector3(
            Mathf.Round(vector.x / gridSize) * gridSize,
            0,
            0
        );
        return result;
    }

    public void Generate()
    {
        List<string> list = new List<string>();
        Transform[] objects = GetComponentsInChildren<Transform>();
        MapStruct mapStruct = new MapStruct();
        foreach (Transform transform in objects)
        {
            GameObject obj = transform.gameObject;
            if (obj.GetComponent<_Item>() || obj.GetComponent<_Obstacle>())
            {
                mapStruct.position = obj.transform.localPosition;
                mapStruct.sprite = obj.GetComponent<SpriteRenderer>().sprite.name;
                mapStruct.tag = obj.tag;
                list.Add(JsonUtility.ToJson(mapStruct));
            }
        }

        string path = @".\Map_" + mapName + ".json";
        Debug.Log(path);
        // Delete the file if it exists.
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        //Create the file.
        using (FileStream fs = File.Create(path))
        {
            foreach (var item in list)
            {
                AddText(fs, item+"\n");
            }
        }
    }
    private static void AddText(FileStream fs, string value)
    {
        byte[] info = new UTF8Encoding(true).GetBytes(value);
        fs.Write(info, 0, info.Length);
    }
}