using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardObjectMovement : MonoBehaviour
{
    public string targetTag;
    private Vector3 speed;
    private Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        speed = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
        targetPos = Camera.main.ScreenToWorldPoint(GameObject.FindGameObjectWithTag(targetTag).transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += speed;
        speed *= 0.97f;
        if (Vector2.Distance(Vector2.zero, speed) <= 0.05f)
        {
            Vector2 pos = transform.position;
            pos = Vector2.Lerp(pos, targetPos, 0.1f);
            transform.position = (Vector3)pos + new Vector3(0, 0, -19);
        }

        if (Vector2.Distance(transform.position, targetPos) <= 0.05f)
        {
            Global.Add("Gold", 100);
            Destroy(gameObject);
        }
    }
}
