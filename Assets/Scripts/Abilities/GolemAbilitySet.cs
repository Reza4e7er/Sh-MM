using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAbilitySet : IAbilitySet
{
    public float mdamage = 3f;
    public float raduis = 2f;

    public float PassiveChance { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool PassiveSuccessful { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    private void AreaAttack(float maindamage)
    {
        Collider[] hits = Physics.OverlapSphere(PlayerController.player.transform.position,raduis);
        foreach(var hit in hits){
            if(hit.tag == "Enemy"){
                Character hitCharacter = hit.GetComponent<Character>();
                hitCharacter.ApplyDamage(mdamage);
                hitCharacter.ApplyKnockBack(30f, PlayerController.player.transform.position);
            }
        }
    }
    private void CiriticalDamage(float damage)
    {

    }
    public void Ability1(){
        Debug.Log("Golem Ability 1");
        AreaAttack(mdamage);

    }
    public void Ability2(){
        Debug.Log("Golem Ability 2");
    }

    public void AbilityPassive() {}
}
