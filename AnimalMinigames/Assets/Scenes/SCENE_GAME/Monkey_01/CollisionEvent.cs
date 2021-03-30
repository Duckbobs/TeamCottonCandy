using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionEvent : MonoBehaviour
{
    public bool isPlayer = false;
    public Text textUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Object")
        {
            Destroy(collision.gameObject);
            if (isPlayer)
            {
                GameSystem_Monkey_01.Score += Random.Range(100, 200);
                textUI.text = StringUtil.NumberFormat(GameSystem_Monkey_01.Score);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
