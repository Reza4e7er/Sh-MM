using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbilitySet
{
    void Ability1();
    void Ability2();
    void AbilityPassive();
    float PassiveChance {get; set;}
    bool PassiveSuccessful {get; set;}
}
