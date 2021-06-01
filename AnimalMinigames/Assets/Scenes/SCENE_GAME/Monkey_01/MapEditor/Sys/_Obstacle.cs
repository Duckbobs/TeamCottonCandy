using UnityEngine;
[ExecuteInEditMode]
public class _Obstacle : MonoBehaviour
{
    public void Update()
    {
        transform.localPosition = RoundVec3(transform.localPosition, 0.5f);
        gameObject.name = "Obs_"+transform.localPosition.x * 2f;
        gameObject.tag = "Obstacle";
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