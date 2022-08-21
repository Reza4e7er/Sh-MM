using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    static public Camera mainCamera;

    private void Update()
    {
        transform.forward = -mainCamera.transform.forward;
    }
}
