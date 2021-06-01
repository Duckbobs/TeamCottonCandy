using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class GridMover : MonoBehaviour
{
    public void Update()
    {
        if (!Application.isPlaying)
        {
            Transform[] gameObjects = GetComponentsInChildren<Transform>();

            foreach (Transform obj in gameObjects)
            {
                if (obj.gameObject != this.gameObject)
                {
                    obj.transform.localPosition = RoundVec3(obj.transform.localPosition, 0.5f);
                    if(obj.tag != "Untagged")
                        obj.name = obj.tag + "_" + obj.transform.localPosition.x * 2f;
                }
            }
        }
    }

    Vector3 RoundVec3(Vector3 vector, float gridSize) {
        Vector3 result = new Vector3(
            Mathf.Round(vector.x / gridSize) * gridSize,
            Mathf.Round(vector.y / gridSize) * gridSize,
            0
        );
        return result;
    }
}