using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipHspeed : MonoBehaviour
{
    Hspeed CompHspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CompHspeed = GetComponent<Hspeed>();
    }

    public void doFlipHspeed()
    {
        CompHspeed.hspeed *= -1;
    }
}
