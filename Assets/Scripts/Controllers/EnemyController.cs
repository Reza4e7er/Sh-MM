using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    //[SerializeField] private float maxDistanceToPlayerToAccack = 1f;
    public List<Character> characters;

    public int groupsCount = 3;
    private int groupsI = 0;


    // calculates directions for all of the characters (called by the MainController)
    public void Calculate()
    {
        CalculateGroup(groupsCount, groupsI);

        if (groupsI>=groupsCount)
            groupsI = 0;
        else
            groupsI++;
    }

    // calculates directions for a portion of the characters
    public void CalculateGroup(int groupsCount, int i)
    {
        Vector2 newDir = new Vector2();

        for (int j=i; j<characters.Count; j+=groupsCount)
        {
            newDir.x = target.position.x - characters[j].transform.position.x;
            newDir.y = target.position.z - characters[j].transform.position.z;
            if (!characters[j].isPlayer && !characters[j].isStunned && !characters[j].isFrozen && !characters[j].isAttacking && newDir.magnitude<=characters[j].attackRange)
                characters[j].Attack();
            newDir.Normalize();
            characters[j].moveDirection = newDir;
        }
    }

    // changes the target transform (player)
    public void ChangeTarget(Character character)
    {
        target = character.transform;
    }
}
