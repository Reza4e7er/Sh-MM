using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MehdisEnemyController : MonoBehaviour
{
    public Transform target;
    [SerializeField] private List<MehdisCharacter> characters;


    // calculates directions for all of the characters (called by the MainController)
    public void Calculate()
    {
        Vector2 newDir = new Vector2();

        foreach (MehdisCharacter character in characters)
        {
            newDir.x = target.position.x - character.transform.position.x;
            newDir.y = target.position.z - character.transform.position.z;
            newDir.Normalize();
            character.moveDirection = newDir;
        }
    }
}
