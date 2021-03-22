using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteMove : MonoBehaviour
{
    public float maxWidth = 1;
    public Hspeed CompHspeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.right * CompHspeed.hspeed/10 * Time.deltaTime;
        if (transform.localPosition.x <= -maxWidth)
        {
            transform.localPosition = new Vector3(
                -maxWidth, transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.x >= maxWidth)
        {
            transform.localPosition = new Vector3(
                maxWidth, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
