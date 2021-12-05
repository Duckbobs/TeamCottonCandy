using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToZero : MonoBehaviour
{
    public GameObject blackObj;
    public bool reverse = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (reverse)
        {
            blackObj.SetActive(false);
            if (transform.localScale.x < 13.0f)
            {
                transform.localScale *= 1.1f;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (transform.localScale.x > 0.2f)
            {
                transform.localScale *= 0.9f;
            }
            else
            {
                blackObj.SetActive(true);
            }
        }
    }
}
