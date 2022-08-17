using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [HideInInspector] public Vector2 moveDirection = Vector2.up;
    public float baseMoveSpeed = 1f;

    private void Update()
    {
        transform.Translate(moveDirection.x*Time.deltaTime, 0f, moveDirection.y*Time.deltaTime);
    }
}
