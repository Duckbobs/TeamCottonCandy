using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public GameObject uiEnd;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 0)
        {
            uiEnd.SetActive(true);
            Destroy(gameObject);
        }    
    }
}
