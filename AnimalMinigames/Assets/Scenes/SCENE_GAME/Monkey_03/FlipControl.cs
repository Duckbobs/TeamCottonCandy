using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipControl : MonoBehaviour
{
    SpriteRenderer CompSprite;
    // Start is called before the first frame update
    void Start()
    {
        CompSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doFlip()
    {
        CompSprite.flipY = !CompSprite.flipY;
        transform.localPosition = new Vector3(transform.localPosition.x, -1 * transform.localPosition.y, transform.localPosition.z);
    }
}
