using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    float degrees = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponentInParent<Transform>().transform.rotation = Quaternion.Euler(Vector3.forward);
        degrees += 10 * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(Vector3.forward * (degrees));
    }
}
