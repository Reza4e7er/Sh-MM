using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public DirectionState directionState = DirectionState.Forward;
}

public enum DirectionState
{
    Forward,
    Right,
    Left
};
