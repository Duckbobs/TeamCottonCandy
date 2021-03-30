using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaSpawner : MonoBehaviour
{
    public GameObject banana;

    bool double_jump = false;
    float timer_jump = 0;
    Vspeed Comp;
    float timer = -1;
    // Start is called before the first frame update
    void Start()
    {
        Comp = GetComponent<Vspeed>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Comp.IsJump())
        {
            timer += Time.deltaTime * 0.5f;
        }
        timer_jump += Time.deltaTime;
        if (timer >= 0.1f)
        {
            Instantiate(banana, transform.position, Quaternion.identity);
            timer = timer - 0.1f;
        }

        if (timer_jump >= 0)
        {
            if (timer_jump >= 3)
            {
                if (Comp.doJump_isJump())
                {
                    timer_jump = 0;
                }
                if (Chance.chance(100))
                {
                    double_jump = true;
                    timer_jump = -0.4f;
                }
            }
            else if (double_jump)
            {
                if (Comp.doJump_isJump())
                {
                    double_jump = false;
                    timer_jump = 0;
                }
            }
        }
    }
}
