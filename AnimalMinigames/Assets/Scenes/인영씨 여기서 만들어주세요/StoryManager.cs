using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public Sprite[] sprites;
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
        // TODO 다음 페이지로

        // TODO if(페이지 끝날시) DoEnd() 호출
    }
    public void DoEnd()
    {
        // 종료 (창을 닫는다)
        Destroy(gameObject);
    }
}
