using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashDamage : MonoBehaviour
{
    public GameObject SplashArea;
    public float SplashSpeed;
    // TimeToDestroySplash, timing;
    public float Splashdamage;
    void Start()
    {
        //  TimeToDestroySplash = 1f;
        //   timing = 0f;
    }

    void Update()
    {

    }
    public void splashdamage()
    {
        GameObject Area = Instantiate(SplashArea, PlayerController.player.transform.position, Quaternion.identity);
        //Area.transform.position += transform.forward * SplashSpeed * Time.deltaTime;
        Rigidbody rigidbody = Area.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;
        rigidbody.drag = 0f;
        rigidbody.AddForce(transform.forward*SplashSpeed*Time.deltaTime,ForceMode.Impulse);
        
        Destroy(Area, 1);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            other.GetComponent<Character>().ApplyDamage(Splashdamage);

        }
    }
}
