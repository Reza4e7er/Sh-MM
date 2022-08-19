using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraController : MonoBehaviour
{
    public PlayerController pl;
    CinemachineVirtualCamera freeLook;
    public GameObject newe;

    void Start()
    {
        freeLook = GetComponent<CinemachineVirtualCamera>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PLChange()
    {   
        freeLook.Follow = pl.player.transform;
        freeLook.LookAt = pl.player.transform;
    }
}
