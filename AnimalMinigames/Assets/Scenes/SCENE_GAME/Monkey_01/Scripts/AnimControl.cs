using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class AnimControl : MonoBehaviour
{
    public SkeletonAnimation skeleton;
    public PlayerMovement compVspeed;

    string beforeState = "";
    string state = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        skeleton.timeScale = PlayerMovement.playerSpeed/2 + 5;

        if (PlayerMovement.playerBoostTime > 0)
        {
            state = "MONKEY__RUN2";
        }
        else if (compVspeed.IsJump() == false)
            state = "MONKEY__RUN";
        else if (compVspeed.vspeed > 0 && compVspeed.GetJumpCount() > 1)
            state = "MONKEY__Roll2";
        else if(compVspeed.vspeed > 0)
            state = "MONKEY_JUMP";

        if (beforeState != state)
        {
            beforeState = state;
            skeleton.state.SetAnimation(0, state, (state == "MONKEY__RUN" || state == "MONKEY__RUN2"));
        }
    }
}
