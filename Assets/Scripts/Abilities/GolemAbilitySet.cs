using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAbilitySet : IAbilitySet
{
    public float mdamage = 3f;
    public float raduis = 2f;
    private void AreaAttack(float maindamage)
    {
        Collider[] hits = Physics.OverlapSphere(PlayerController.player.transform.position,raduis);
        foreach(var hit in hits){
            if(hit.tag == "Enemy"){
                hit.GetComponent<Character>().ApplyDamage(mdamage);
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
}
