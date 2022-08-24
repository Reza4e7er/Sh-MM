using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class ZombieAttack : MonoBehaviour, IAttack
{
    //private Character character;
    [SerializeField] private float damageAmount = 1f;
    [SerializeField] private float attackTime = 1f;
    [HideInInspector] public Character Character { get; set;}

    public void AttackAsEnemy()
    {
        Character.animator.SetTrigger("Attack");
        Character.isAttacking = true;
        FunctionTimer.Create(AttackAsEnemyEnd, attackTime);
    }
    private void AttackAsEnemyEnd()
    {
        PlayerController.ApplyDamage(damageAmount);
        Character.isAttacking = false;
    }

    public void AttackAsPlayer()
    {
        throw new System.NotImplementedException();
    }
}
