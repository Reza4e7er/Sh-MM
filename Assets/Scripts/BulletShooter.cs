using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public float speed;
    public GameObject BulletPrefab;
    [SerializeField] private Transform parentTransform;
    //public PlayerController pl;
    float time1, TimeFire;
    void Start()
    {
        time1 = 0f;
        TimeFire = 1f;
    }

    void Update()
    {
        time1 += Time.deltaTime;
        if (time1 > TimeFire)
        {
            time1 = 0f;
            Shoot();
        }
    }
    public void Shoot()
    {
        // Debug.Log("Shooting");
        Transform firePoint = PlayerController.player.transform.GetChild(0);
        GameObject bullet = Instantiate(BulletPrefab, firePoint.position, firePoint.rotation, parentTransform);
        // bullet.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        bullet.GetComponent<Rigidbody>().AddForce(firePoint.forward*speed);
    }
    private void OnTriggerEnter(Collider other)
    {

    }
}
