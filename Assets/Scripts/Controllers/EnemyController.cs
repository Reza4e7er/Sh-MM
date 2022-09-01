using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    //[SerializeField] private float maxDistanceToPlayerToAccack = 1f;
    public List<Character> characters;


    // calculates directions for all of the characters (called by the MainController)
    public void Calculate()
    {
        Vector2 newDir = new Vector2();

        foreach (Character character in characters)
        {
            newDir.x = target.position.x - character.transform.position.x;
            newDir.y = target.position.z - character.transform.position.z;
            if (!character.isPlayer && !character.isAttacking && newDir.magnitude<=character.attackRange)
                character.Attack();
            newDir.Normalize();
            character.moveDirection = newDir;
        }
    }

    // changes the target transform (player)
    public void ChangeTarget(Character character)
    {
        target = character.transform;
    }
}
