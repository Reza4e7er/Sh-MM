using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public DirectionState directionState = DirectionState.Forward;

    private void Update()
    {
        directionState = DirectionState.Forward;

        if (Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);

            // check if touch should be acounted
            // not implemented!


            // turn
            if (touch.position.x>=Screen.currentResolution.width/2)
            {
                directionState = DirectionState.Right;
            }
            else
            {
                directionState = DirectionState.Left;
            }
        }
    }
}

public enum DirectionState
{
    Forward,
    Right,
    Left
};
