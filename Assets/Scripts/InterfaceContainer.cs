using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbility
{
    void AreaAttack(float maindamage);
    void CiriticalDamage(float damage);
}
