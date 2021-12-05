using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveToStageFlat : MonoBehaviour
{
    public List<FlatUpdater> flatList = new List<FlatUpdater>();
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(-100, -100, 0);
        foreach (FlatUpdater flat in flatList)
        {
            if (flat.Wait_Object.activeSelf || flat.AllClear_Object.activeSelf)
            {
                if (Global.Get(flat.valueName) >= Global.Get(flat.valueName, "Max"))
                {
                    // 보상 미수령
                    continue;
                }
                transform.position = flat.transform.position;
            }
        }
    }
}
