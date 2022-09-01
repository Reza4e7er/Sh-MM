using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IAbility
{
    public float mdamage;
    public float raduis;
    public void AreaAttack(float maindamage)
    {
        Collider[] hits = Physics.OverlapSphere(PlayerController.player.transform.position,raduis);
        foreach(var hit in hits){
            if(hit.tag == "Enemy"){
                hit.GetComponent<Character>().ApplyDamage(mdamage);
            }
        }
    }
    public void CiriticalDamage(float damage)
    {

    }
    public void Ability1(){
        AreaAttack(mdamage);
    }
    void Ability2(){

    }
}
