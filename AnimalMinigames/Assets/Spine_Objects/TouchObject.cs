using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Spine.Unity;

public class TouchObject : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        GetComponent<SkeletonAnimation>().state.SetAnimation(0, "animation", false);
        Debug.Log("Click");
    }
}
