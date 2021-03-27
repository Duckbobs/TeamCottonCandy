using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public Transform playerTrans;
    public float radius;


    virtual public void OnCollision()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTrans != null)
        {
            if (Vector3.Distance(
                    (Vector2)playerTrans.position, (Vector2)transform.position
                ) < radius) {
                // 충돌 시 OnCollision() 실행
                playerTrans.gameObject.GetComponent<AddScore>().OnCollision();
            }
        } else
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Player");
            this.playerTrans = obj.transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, radius);
    }
}
