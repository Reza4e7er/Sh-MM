using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [HideInInspector] public Vector2 moveDirection = Vector2.up;
    public float baseMoveSpeed = 1f;
    public float currentMoveSpeed;
    public GameObject glassesMeshObject;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        currentMoveSpeed = baseMoveSpeed;
    }

    private void Update()
    {
        // move the character
        _rigidbody.MovePosition(transform.position+new Vector3(moveDirection.x, 0f, moveDirection.y)*Time.deltaTime*currentMoveSpeed);
        // rotate the character
        _rigidbody.MoveRotation(Quaternion.Euler(0f, Mathf.Atan2(moveDirection.x, moveDirection.y)*Mathf.Rad2Deg, 0f));
    }
}
