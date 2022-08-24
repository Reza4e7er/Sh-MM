using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

[RequireComponent(typeof(InputManager))]
public class PlayerController : MonoBehaviour
{
    public string playerTag = "Player";
    public string enemyTag = "Enemy";
    [HideInInspector] public InputManager inputManager;
    // [SerializeField] private float turnSpeed = 1f;

    public static bool isInvincible = false;
    public static float invincibleTime = 3f;
    [SerializeField] private float moveSpeedMult = 1.5f;
    [SerializeField] private float healthBarSizeMult = 1.2f;

    [SerializeField] private Character playerCharcterScript;
    [SerializeField] public static Character player; // *****
    [SerializeField] private Canvas playerIndicator;
    private Vector2 playerLastDir = Vector2.up;
    private Vector2 playerDir;

    // private void Awake()
    // {
    //     inputManager = GetComponent<InputManager>();
    // }

    private void Start()
    {
        PlayerController.player = playerCharcterScript;
        SetAsPlayer(ref player);
    }

    // called by the MainController to calculate the player direction
    public void Calculate()
    {
        // change players' direction based on input
        // switch (inputManager.directionState)
        // {
        //     case DirectionState.Forward:
        //         playerDir = playerLastDir;
        //         break;
        //     case DirectionState.Right:
        //         playerDir = Quaternion.Euler(0,0,turnSpeed*Time.deltaTime)*playerLastDir;
        //         break;
        //     case DirectionState.Left:
        //         playerDir = Quaternion.Euler(0,0,-turnSpeed*Time.deltaTime)*playerLastDir;
        //         break;
        //     default:
        //         break;
        // }
        playerDir = inputManager.inputVector;
        //playerDir.Normalize();

        if (playerDir.magnitude!=0)
        {
            player.moveDirection = playerDir;
            playerLastDir = playerDir;
        }
        else
        {
            player.moveDirection = playerLastDir;
        }
    }

    // applies damage to the player
    public static void ApplyDamage(float damageAmount)
    {
        if (!isInvincible)
            player.ApplyDamage(damageAmount);
    }

    // called when a new player is assigned
    private void SetAsPlayer(ref Character character)
    {
        isInvincible = true;
        FunctionTimer.Create(()=>{isInvincible=false;}, invincibleTime);

        player = character;
        player.gameObject.tag = playerTag;
        player.isPlayer = true;
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
        player.gameObject.tag = enemyTag;
        player.isPlayer = false;
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
    }

    public void DamageTest()
    {
        player.ApplyDamage(2f);
    }
}
