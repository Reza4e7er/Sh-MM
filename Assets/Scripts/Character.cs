using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IPoolable
{
    [HideInInspector] public Vector2 moveDirection = Vector2.up;
    [SerializeField] private int poolingID;
    public int PoolingID{ get; set;}
    public GameObject ThisGameObject{get{return gameObject;}}
    public bool isPlayer = false;
    public CharacterType characterType = CharacterType.Zombie;
    public bool isAttacking = false;
    public float attackRange = 1f;
    public float baseMoveSpeed = 1f;
    public float currentMoveSpeed;
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private float health;
    public HealthBar healthBar;
    private Rigidbody _rigidbody;
    public Animator animator;

    private IAttack attackScript; // a component with all the attack logic

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>(true);
        attackScript = GetComponent<IAttack>();
        attackScript.Character = (Character) this;

        healthBar.ResetComponents();

        PoolingID = poolingID;
    }

    private void OnEnable()
    {
        currentMoveSpeed = baseMoveSpeed;
        health = maxHealth;
        UpdateHealthBar();
    }

    // reassigns components
    public void ResetComponents()
    {
        _rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>(true);
        attackScript = GetComponent<IAttack>();
        attackScript.Character = (Character) this;

        healthBar.ResetComponents();
        currentMoveSpeed = baseMoveSpeed;
        health = maxHealth;
        UpdateHealthBar();
    }

    private void Update()
    {
        if (!isAttacking)
        {
            // move the character
            _rigidbody.MovePosition(transform.position+new Vector3(moveDirection.x, 0f, moveDirection.y)*Time.deltaTime*currentMoveSpeed);
        }
        // rotate the character
        _rigidbody.MoveRotation(Quaternion.Euler(0f, Mathf.Atan2(moveDirection.x, moveDirection.y)*Mathf.Rad2Deg, 0f));
    
    }

    // based on isPlayer calls an attack function
    public void Attack()
    {
        if (!isPlayer)
        {
            attackScript.AttackAsEnemy();
        }
    }

    // called by the bullets to damage this character
    public void ApplyDamage(float damageAmount)
    {
        health -= damageAmount;
        UpdateHealthBar();
        if (health<=0f)
            Die();
    }

    // updates this characters health bar
    public void UpdateHealthBar()
    {
        healthBar.UpdateBar(health/maxHealth);
    }

    // called when the character dies
    public void Die()
    {
        healthBar.UpdateBar(0f);
        //gameObject.SetActive(false);
        PoolsManager.Instance.ReturnToPool(gameObject, poolingID);
    }
}


public enum CharacterType
{
    Zombie,
    Golem
};