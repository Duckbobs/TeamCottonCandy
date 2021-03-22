using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidRotate : MonoBehaviour
{
    public Transform otherTrans;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.forward * otherTrans.rotation.eulerAngles.z);
    }
}
