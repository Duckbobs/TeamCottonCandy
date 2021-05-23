using UnityEngine;

[ExecuteInEditMode]
public class MapInfo : MonoBehaviour
{
    public uint totalLine = 1;
    public GameObject top;
    public GameObject bottom;
    public void Update()
    {
        GameObject topObject = top;
        GameObject bottomObject = bottom;
        float distance = totalLine * 0.5f;
        if (topObject.transform.localPosition.y != distance)
            topObject.transform.localPosition = new Vector3(0, distance, topObject.transform.localPosition.z);
        if (bottomObject.transform.localPosition.y != -distance)
            bottomObject.transform.localPosition = new Vector3(0, -distance, bottomObject.transform.localPosition.z);

        if (transform.localPosition.y != distance)
            transform.localPosition = new Vector3(0, distance, transform.localPosition.z);

    }
}
