using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
//[RequireComponent(typeof(EnemyController))]
//[RequireComponent(typeof(InputManager))]
public class MainController : MonoBehaviour
{
    private PlayerController playerController;
    private MehdisEnemyController enemyController;
    [SerializeField] private InputManager inputManager;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        enemyController = GetComponent<MehdisEnemyController>();
        playerController.inputManager = inputManager;
    }

    void Update()
    {
        enemyController.Calculate();
        playerController.Calculate();
    }
}
