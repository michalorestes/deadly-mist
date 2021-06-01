using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputController
{

    static public bool IsContextButtonPressed()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
    
}
