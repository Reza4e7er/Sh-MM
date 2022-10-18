using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreAbilitySet : IAbilitySet
{
    [SerializeField]
    private float passiveChance = 0.2f;
    public float PassiveChance {get{return passiveChance;} set{passiveChance=value;}}
    [SerializeField]
    private bool passiveSuccessful = false;
    public bool PassiveSuccessful {get{return passiveSuccessful;} set{passiveSuccessful=value;}}

    public float splashSpeed = 4f;


    public void Ability1()
    {
        throw new System.NotImplementedException();
    }

    public void Ability2()
    {
        throw new System.NotImplementedException();
    }

    public void AbilityPassive()
    {
        Debug.Log("Splash!");
        SplashDamage();
    }

    private void SplashDamage()
    {
        GameObject Area = GameObject.Instantiate(PlayerController.SplashPrefab, PlayerController.player.transform.position, PlayerController.player.transform.rotation);
        //Area.transform.position += transform.forward * SplashSpeed * Time.deltaTime;
        Rigidbody rigidbody = Area.GetComponent<Rigidbody>();
        rigidbody.AddForce(PlayerController.player.transform.forward*splashSpeed,ForceMode.Impulse);
        
        GameObject.Destroy(Area, 10);
    }
}
