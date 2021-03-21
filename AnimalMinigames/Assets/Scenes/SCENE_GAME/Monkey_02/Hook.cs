using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public UI_BtnDownEvent BtnDownEvent;

    Transform staticPosition = null;
    Transform hookedPosition = null;
    float fly = 0;
    float degrees = 0;
    float stringLength;
    Vspeed CompVspeed;
    LineRenderer CompLineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        CompVspeed = GetComponent<Vspeed>();
        CompLineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        hookedPosition = null;
        if (BtnDownEvent.isBtnDown)
        {
            if (staticPosition == null)
            {
                GameObject[] objects = GameObject.FindGameObjectsWithTag("Object");
                foreach (var item in objects)
                {
                    if (isCanHooked(item.transform))
                    {
                        if (item.transform.position.x > transform.position.x)
                        {
                            staticPosition = item.transform;
                            staticPosition.GetComponent<Hspeed>().hspeed *= 3;
                            break;
                        }
                    }
                }
            }
            if (staticPosition != null)
            {
                if (isCanHooked(staticPosition))
                {
                    hookedPosition = staticPosition;
                }
            }
        }

        if (hookedPosition == null)
        {
            if (staticPosition != null)
            {
                Destroy(staticPosition.gameObject);
                staticPosition = null;
            }
            CompLineRenderer.SetPosition(0, Vector3.zero);
            CompLineRenderer.SetPosition(1, Vector3.zero);
            // WHEN FALLING
            degrees += 300 * Time.deltaTime;
            transform.rotation = Quaternion.Euler(Vector3.forward * (degrees));

            fly -= 10 * Time.deltaTime;
            if (fly > 0)
            {
                CompVspeed.doUp();
            }
            if (gameObject.transform.localPosition.y <= CompVspeed.groundY)
            {
                // WHEN GROUNDED
                transform.rotation = Quaternion.Euler(Vector3.forward);
            }
        }
        else
        {
            CompVspeed.doUp();
            CompLineRenderer.SetPosition(0, transform.position);
            CompLineRenderer.SetPosition(1, hookedPosition.transform.position);

            Vector3 direction = (hookedPosition.transform.position - transform.position);
            direction = direction.normalized;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
            degrees = transform.rotation.z;
            fly = 1;
        }
    }

    bool isCanHooked(Transform hookObject)
    {
        Vector3 my_pos = new Vector3(transform.position.x, transform.position.y, 0);
        Vector3 static_pos = new Vector3(hookObject.position.x, hookObject.position.y, 0);
        stringLength = Vector3.Distance(my_pos, static_pos);
        if (stringLength <= 4.6f
            && my_pos.y < static_pos.y)
        {
            return true;
        }
        return false;
    }
}
