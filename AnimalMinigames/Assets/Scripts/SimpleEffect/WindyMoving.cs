using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindyMoving : MonoBehaviour
{
    public float moveSpeed = 0.25f;
    public float moveSize = 1.0f;
    float xPos, yPos;
    float xDest, yDest;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        xPos = transform.localPosition.x;
        yPos = transform.localPosition.y;
        xDest = Mathf.Clamp(Random.Range(transform.localPosition.x - moveSize, transform.localPosition.x + moveSize), xPos - moveSize, xPos + moveSize);
        yDest = Mathf.Clamp(Random.Range(transform.localPosition.y - moveSize, transform.localPosition.y + moveSize), yPos - moveSize, yPos + moveSize);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * 1.0f;
        if (timer > 2f || Mathf.Abs(xDest - transform.localPosition.x) <= 0.2f)
        {
            timer = 0;
            xDest = Mathf.Clamp(Random.Range(transform.localPosition.x - moveSize, transform.localPosition.x + moveSize), xPos - moveSize, xPos + moveSize);
            yDest = Mathf.Clamp(Random.Range(transform.localPosition.y - moveSize, transform.localPosition.y + moveSize), yPos - moveSize, yPos + moveSize);
        }


        float speed = moveSpeed * Time.deltaTime;
        transform.localPosition = new Vector3(

            transform.localPosition.x + Mathf.Clamp(xDest - transform.localPosition.x, -speed, speed),
            transform.localPosition.y + Mathf.Clamp(yDest - transform.localPosition.y, -speed, speed),

            transform.localPosition.z);
    }
}
