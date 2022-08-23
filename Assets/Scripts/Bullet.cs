using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public GameObject BulletPrefab;
    public PlayerController pl;
    float time1, TimeFire;
    void Start()
    {
        time1 = 0f;
        TimeFire = 1f;
    
    }

    void Update()
    {
        time1 += 1 * Time.deltaTime;
        if (time1 > TimeFire)
        {
            time1 = 0f;
            Shoot();
        }
    }
    public void Shoot()
    {
       // Debug.Log("Shooting");
        GameObject bullet = Instantiate(BulletPrefab,pl.player.transform.position , Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * Speed);
    }
    private void OnTriggerEnter(Collider other) {
        
    }
}
