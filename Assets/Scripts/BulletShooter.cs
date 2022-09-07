using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public float speed;
    public bool canShoot = true;
    public GameObject BulletPrefab;
    [SerializeField] private Transform parentTransform;
    //public PlayerController pl;
    float time1, TimeFire;

    public static Bullet lastBullet;
    void Start()
    {
        time1 = 0f;
        TimeFire = 1f;
    }

    void Update()
    {
        if (canShoot)
        {
            time1 += Time.deltaTime;
            if (time1 > TimeFire)
            {
                time1 = 0f;
                Shoot();
            }
        }
    }
    public void Shoot()
    {
        Transform firePoint = PlayerController.player.transform.GetChild(0);
        Bullet bullet = PoolsManager.Instance.Get(0, out bool newObjectInstantiated).GetComponent<Bullet>();
        bullet.gameObject.SetActive(true);
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;
        bullet.transform.SetParent(parentTransform);
        
        lastBullet = bullet;

        if (UnityEngine.Random.Range(0f, 1f)<=PlayerController.passiveChance)
        {
            PlayerController.AbilityPassiveAction();
        }
    }
}
