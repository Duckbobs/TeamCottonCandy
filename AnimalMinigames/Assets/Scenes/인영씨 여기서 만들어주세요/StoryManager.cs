using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    public Sprite[] sprites;
    public Image imageComp;
    int n = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DoNext()
    {
        imageComp.sprite = sprites[n++];
        // TODO 다음 페이지로
        

        // TODO if(페이지 끝날 시) DoEnd() 호출
        if(sprites.Length <= n)
        {
            DoEnd();
        }
    }

    public void DoEnd()
    {
        // 종료 (창을 닫는다)
        Destroy(gameObject);
    }
}
