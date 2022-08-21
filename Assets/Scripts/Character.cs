using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [HideInInspector] public Vector2 moveDirection = Vector2.up;
    public bool isPlayer = false;
    public float baseMoveSpeed = 1f;
    public float currentMoveSpeed;
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private float health;
    public HealthBar healthBar;
    private Rigidbody _rigidbody;
    public Animator animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();

        currentMoveSpeed = baseMoveSpeed;
        health = maxHealth;
    }

    private void Start()
    {
        UpdateHealthBar();
    }

    private void Update()
    {
        // move the character
        _rigidbody.MovePosition(transform.position+new Vector3(moveDirection.x, 0f, moveDirection.y)*Time.deltaTime*currentMoveSpeed);
        // rotate the character
        _rigidbody.MoveRotation(Quaternion.Euler(0f, Mathf.Atan2(moveDirection.x, moveDirection.y)*Mathf.Rad2Deg, 0f));
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
        gameObject.SetActive(false);
    }
}
