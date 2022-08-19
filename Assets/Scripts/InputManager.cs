using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public DirectionState directionState = DirectionState.Forward;
    [SerializeField] private Camera mainCamera;
    private bool bodyChangeActive = false;
    public RectTransform[] areasToIgnore;

    [SerializeField] private UnityEvent<Character> OnCharacterRayCast;
    [SerializeField] private UnityEvent OnBodyChangeStarted;
    [SerializeField] private UnityEvent OnBodyChangeEnded;




    private void Update()
    {
        directionState = DirectionState.Forward;

        if (Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);

            // check if touch should be acounted
            // not implemented!

            if (!bodyChangeActive)
            {
                // turn
                if (touch.position.x>=Screen.currentResolution.width/2)
                {
                    directionState = DirectionState.Left;
                }
                else
                {
                    directionState = DirectionState.Right;
                }
            }
            else
            {
                Ray ray = mainCamera.ScreenPointToRay(touch.position);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.tag=="Character")
                {
                    Character character = hitInfo.collider.GetComponent<Character>();
                    if (OnCharacterRayCast!=null)
                        OnCharacterRayCast.Invoke(character);
                    if (OnBodyChangeEnded!=null)
                        OnBodyChangeEnded.Invoke();
                    bodyChangeActive = false;
                }
            }
        }
    }

    public void StartBodyChange()
    {
        if (OnBodyChangeStarted!=null)
            OnBodyChangeStarted.Invoke();
        bodyChangeActive = true;
    }
}

public enum DirectionState
{
    Forward,
    Right,
    Left
};

//[System.Serializable]
//public class CharacterEvent : Unity
