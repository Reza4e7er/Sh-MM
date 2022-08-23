using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(InputManager))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector] public InputManager inputManager;
    [SerializeField] private float turnSpeed = 1f;
    [SerializeField] private float moveSpeedMult = 1.5f;
    [SerializeField] private float healthBarSizeMult = 1.2f;
    public Character player; // *****
    [SerializeField] private Canvas playerIndicator;
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
        player = character;
        playerIndicator.transform.SetParent(player.transform);
        playerIndicator.transform.localPosition = Vector3.zero;
        player.animator.SetBool("Running", true);
        playerLastDir = player.moveDirection;
        player.currentMoveSpeed = player.baseMoveSpeed*moveSpeedMult;
        player.healthBar.transform.localScale *= healthBarSizeMult;
        player.healthBar.isPlayer = true;
        player.UpdateHealthBar();
    }

    // called when a character is no longer the player
    private void UnsetAsPlayer()
    {
        player.animator.SetBool("Running", false);
        player.currentMoveSpeed = player.baseMoveSpeed;
        player.healthBar.transform.localScale /= healthBarSizeMult;
        player.healthBar.isPlayer = false;
        player.UpdateHealthBar();
        //player.Die();
    }

    // changes players' body
    public void ChangeBody(Character character)
    {
        UnsetAsPlayer();
        SetAsPlayer(ref character);
        player.transform.tag = "Player";
    }

    public void DamageTest()
    {
        player.ApplyDamage(2f);
    }
}
