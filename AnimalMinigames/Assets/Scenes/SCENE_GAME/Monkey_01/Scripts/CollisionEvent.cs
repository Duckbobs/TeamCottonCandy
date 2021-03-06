using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionEvent : MonoBehaviour
{
    public AudioClip soundPoint;
    public AudioSource audioSource;
    public bool isPlayer = false;
    public Text textUI;
    public Text textUI_Gold;
    private int goldCount = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPlayer)
        {
            switch (collision.tag)
            {
                case "Gold":
                    // 획득 사운드 재생
                    Global.Add("Gold", 10);
                    audioSource.PlayOneShot(soundPoint);
                    goldCount += 10;
                    textUI_Gold.text = StringUtil.NumberFormat(goldCount);
                    collision.gameObject.SetActive(false);
                    break;
                case "Banana_001":
                    // 획득 사운드 재생
                    Global.Add("Banana_001", 1);
                    audioSource.PlayOneShot(soundPoint);
                    GameSystem_Monkey_01.Score += 1;//Random.Range(100, 200);
                    textUI.text = StringUtil.NumberFormat(GameSystem_Monkey_01.Score);
                    collision.gameObject.SetActive(false);
                    break;
                case "Item":
                    PlayerMovement.playerBoostTime = 3.0f;
                    collision.gameObject.SetActive(false);
                    break;
                case "Obstacle":
                    PlayerMovement.playerDamagedTime = 0.3f;
                    collision.gameObject.SetActive(false);
                    break;
                case "Trigger":
                    Transform[] collection = TriggerObject.tutoParent.GetComponentsInChildren<Transform>(true);
                    foreach (Transform item in collection)
                    {
                        if (item.gameObject.name == collision.gameObject.GetComponent<TriggerObject>().destroyTtargetName)
                        {
                            item.gameObject.SetActive(false);
                        }
                        if (item.gameObject.name == collision.gameObject.GetComponent<TriggerObject>().targetName)
                        {
                            if(item.gameObject.GetComponent<TalkOrder>() != null)
                                FloorMover.isGameStop = true;
                            item.gameObject.SetActive(true);
                            Destroy(collision.gameObject);
                            break;
                        }
                    }
                    break;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isPlayer)
        {
            switch (collision.tag)
            {
                case "TotemFloor":
                    PlayerMovement.totemY = collision.transform.position.y;
                    PlayerMovement.totemYtime = 1.0f;

                    Debug.Log(PlayerMovement.totemY);
                    break;
            }
        }
    }

    private void Start()
    {
    }
}
