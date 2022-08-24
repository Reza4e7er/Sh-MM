using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    Character Character{get; set;}
    void AttackAsEnemy();
    void AttackAsPlayer();
}
