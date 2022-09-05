using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    //public DirectionState directionState = DirectionState.Forward;
    [HideInInspector] public Vector2 inputVector = new Vector2();
    [HideInInspector] public Camera mainCamera;
    [SerializeField] private FixedJoystick joystick;
    private bool bodyChangeActive = false;
    public RectTransform[] areasToIgnore;

    [SerializeField] private UnityEvent<Character> OnCharacterRayCast;
    [SerializeField] private UnityEvent OnBodyChangeStarted;
    [SerializeField] private UnityEvent OnBodyChangeEnded;




    private void Update()
    {
        //directionState = DirectionState.Forward;

        if (Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);

            // check if touch should be ignored
            bool ignoreTouch = false;
            foreach (RectTransform rect in areasToIgnore)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(rect, touch.position))
                {
                    ignoreTouch = true;
                    break;
                }
            }

            if (!bodyChangeActive)
            {
                inputVector.x = -joystick.Vertical;
                inputVector.y = joystick.Horizontal;
                inputVector.Normalize();
            }
            else if (!ignoreTouch)
            {
                Ray ray = mainCamera.ScreenPointToRay(touch.position);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.tag=="Enemy")
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
