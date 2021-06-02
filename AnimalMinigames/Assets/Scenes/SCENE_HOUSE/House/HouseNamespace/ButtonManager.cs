using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace House
{
    public class ButtonManager
    {
        public static GameObject[] inAppliedScreen;
        public static GameObject[] inModifyingScreen;

        public static void SetMode(string mode)
        {
            if( mode == "modifying" )
            {
                foreach( var _obj in inModifyingScreen )
                {
                    _obj.SetActive(true);
                }
                foreach ( var _obj in inAppliedScreen)
                {
                    _obj.SetActive(false);
                }
            }
            else if( mode == "applied" ) {
                foreach( var _obj in inAppliedScreen )
                {
                    _obj.SetActive(true);
                }
                foreach ( var _obj in inModifyingScreen)
                {
                    _obj.SetActive(false);
                }
            }
        }
    }
}

