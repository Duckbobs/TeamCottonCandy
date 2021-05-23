using UnityEngine;
[ExecuteInEditMode]
public class _Camera : MonoBehaviour
{
    public void Update()
    {
        transform.localPosition = RoundVec3(transform.localPosition, 0.5f);
    }

    Vector3 RoundVec3(Vector3 vector, float gridSize) {
        Vector3 result = new Vector3(
            Mathf.Round(vector.x / gridSize) * gridSize,
            2,
            vector.z
        );
        return result;
    }
}