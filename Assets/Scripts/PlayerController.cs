using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(InputManager))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector] public InputManager inputManager;
    [SerializeField] private float turnSpeed = 1f;
    public Character player;
    private Vector2 playerLastDir = Vector2.up;
    private Vector2 playerDir;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        // change players' direction based on input
        switch (inputManager.directionState)
        {
            case DirectionState.Forward:
                playerDir = playerLastDir;
                break;
            case DirectionState.Right:
                playerDir = Quaternion.Euler(0,0,turnSpeed*Time.deltaTime)*playerLastDir;
                break;
            case DirectionState.Left:
                playerDir = Quaternion.Euler(0,0,-turnSpeed*Time.deltaTime)*playerLastDir;
                break;
            default:
                break;
        }

        playerDir.Normalize();
        Debug.Log(playerDir);
        Debug.Log(playerDir.magnitude);

        player.moveDirection = playerDir;

        playerLastDir = playerDir;
    }
}
