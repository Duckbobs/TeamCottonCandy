using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hspeed : MonoBehaviour
{
    public float hspeed = -2f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().transform.position = new Vector3(
            gameObject.transform.position.x + hspeed * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
        if (gameObject.transform.position.x < -6)
        {
            Destroy(gameObject);
        }
    }
}
