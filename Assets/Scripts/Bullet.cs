using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 3f;
    [SerializeField] private int penitration = 1;
    [SerializeField] private float activeTime = 10f;

    private void OnEnable()
    {
        FunctionTimer.Create(DestroyBullet, activeTime);
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag=="Enemy")
        {
            Debug.Log("sthshsh");
            coll.GetComponent<Character>().ApplyDamage(damage);

            penitration--;
            if (penitration<=0)
                DestroyBullet();
        }
    }

    // called whenever bullet should be disabled
    private void DestroyBullet()
    {
        gameObject.SetActive(false);
    }
}
