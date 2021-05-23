using UnityEngine;
[ExecuteInEditMode]
public class _Group : MonoBehaviour
{
    
    public void Update()
    {
        transform.localPosition = RoundVec3(transform.localPosition, 0.5f);
        gameObject.name = "Group_"+transform.localPosition.x * 2f;
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
}