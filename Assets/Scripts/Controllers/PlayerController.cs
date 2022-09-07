using System;
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
    public static float invincibleTime = 2f;
    private CharacterType currentPlayerType;
    [SerializeField] private float moveSpeedMult = 1.5f;
    [SerializeField] private float healthBarSizeMult = 1.2f;

    [SerializeField] private Character playerCharcterScript;
    [SerializeField] public static Character player; // *****
    [SerializeField] private Canvas playerIndicator;
    private Vector2 playerLastDir = Vector2.up;
    private Vector2 playerDir;

    private Action Ability1Action;
    private Action Ability2Action;
    public static Action AbilityPassiveAction;
    public static float passiveChance;

    private BulletShooter bulletShooter;


    private void Awake()
    {
        bulletShooter = GetComponent<BulletShooter>();
    }

    private void Start()
    {
        // abilitySets.Add(new ZombieAbilitySet());
        // abilitySets.Add(new GolemAbilitySet());
        abilitySets.Add(new WizardAbilitySet());
        abilitySets.Add(new GolemAbilitySet());

        PlayerController.player = playerCharcterScript;
        SetAsPlayer(ref player);

        Ability1Action = abilitySets[0].Ability1;
        Ability2Action = abilitySets[0].Ability2;
        AbilityPassiveAction = abilitySets[0].AbilityPassive;
        passiveChance = abilitySets[0].PassiveChance;
    }

    // called by the MainController to calculate the player direction
    public void Calculate()
    {
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
        FunctionTimer.Create(()=>{isInvincible=false;}, invincibleTime, "Invincible");

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
        if (currentPlayerType!=character.characterType)
        {
            currentPlayerType = character.characterType;
            Debug.Log("changed types:"+currentPlayerType.ToString());
            Ability1Action = abilitySets[(int)currentPlayerType].Ability1;
            Ability2Action = abilitySets[(int)currentPlayerType].Ability2;
            AbilityPassiveAction = abilitySets[0].AbilityPassive;
            passiveChance = abilitySets[0].PassiveChance;

            if (currentPlayerType==CharacterType.Wizard)
                bulletShooter.canShoot = true;
            else
                bulletShooter.canShoot = false;
        }
        player.transform.tag = "Player";
    }

    public void DamageTest()
    {
        player.ApplyDamage(2f);
    }


    //******Abilities******
    //[Header("Abilities")]
    private List<IAbilitySet> abilitySets = new List<IAbilitySet>();
    

    // calls the first ability
    public void Ability1()
    {
        if (Ability1Action!=null)
            Ability1Action();
    }

    // calls the second ability
    public void Ability2()
    {
        if (Ability2Action!=null)
            Ability2Action();
    }
}
