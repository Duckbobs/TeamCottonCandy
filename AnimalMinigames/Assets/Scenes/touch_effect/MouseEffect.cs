using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEffect : MonoBehaviour
{
    public GameObject Dokkidokki_effect;
    float spawnsTime;
    public float defaultTime = 0.05f;
    void Update()
    {
        if (Input.GetMouseButton(0)&&spawnsTime>=defaultTime)
        {
            HeartCreat();
            spawnsTime = 0;
        }
        spawnsTime += Time.deltaTime;
    }

    void HeartCreat()
    {
        Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mPosition.z = 0;
        Instantiate(Dokkidokki_effect, mPosition, Quaternion.identity);
    }
}
