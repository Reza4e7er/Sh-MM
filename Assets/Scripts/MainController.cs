using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
//[RequireComponent(typeof(EnemyController))]
//[RequireComponent(typeof(InputManager))]
public class MainController : MonoBehaviour
{
    private PlayerController playerController;
    private EnemyController enemyController;
    [SerializeField] private InputManager inputManager;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        enemyController = GetComponent<EnemyController>();
        playerController.inputManager = inputManager;
    }

    void Update()
    {
        enemyController.Calculate();
        playerController.Calculate();
    }
}
