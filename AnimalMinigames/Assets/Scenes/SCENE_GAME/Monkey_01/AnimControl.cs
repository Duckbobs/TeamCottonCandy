using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class AnimControl : MonoBehaviour
{
    public SkeletonAnimation skeleton;
    public Vspeed compVspeed;

    string beforeState = "";
    string state = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(compVspeed.vspeed < 0)
            state = "CAT_JUMP_DOWN";
        else if (compVspeed.vspeed > 0)
            state = "CAT_JUMP_UP";
        else
            state = "walk";

        if (beforeState != state)
        {
            beforeState = state;
            skeleton.state.SetAnimation(0, state, (state == "walk"));
        }
    }
}
