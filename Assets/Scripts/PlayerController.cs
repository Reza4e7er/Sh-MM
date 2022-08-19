using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(InputManager))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector] public InputManager inputManager;
    [SerializeField] private float turnSpeed = 1f;
    [SerializeField] private float moveSpeedMult = 1.5f;
    public Character player; // *****
    private Vector2 playerLastDir = Vector2.up;
    private Vector2 playerDir;

    // private void Awake()
    // {
    //     inputManager = GetComponent<InputManager>();
    // }

    private void Start()
    {
        SetAsPlayer(ref player);
    }

    // called by the MainController to calculate the player direction
    public void Calculate()
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

        player.moveDirection = playerDir;

        playerLastDir = playerDir;
    }

    // called when a new player is assigned
    private void SetAsPlayer(ref Character character)
    {
        Debug.Log("Set");
        //UnsetAsPlayer(ref player);
        player = character;
        player.currentMoveSpeed = player.baseMoveSpeed*moveSpeedMult;
        player.glassesMeshObject.GetComponent<Renderer>().material.color = Color.red;
    }

    // called when a character is no longer the player
    private void UnsetAsPlayer(ref Character character)
    {
        Debug.Log("Unset");
        player.currentMoveSpeed = player.baseMoveSpeed;
        player.glassesMeshObject.GetComponentInChildren<Renderer>().material.color = Color.white;
    }
}
