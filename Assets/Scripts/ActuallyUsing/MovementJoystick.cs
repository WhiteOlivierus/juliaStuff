using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementJoystick : MonoBehaviour
{

    public GameObject joystick;
    public GameObject joystickBG;
    public Vector2 joystickVec;
    public float joystickSizeMovement;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;
    private float joystickRadius;

    // Start is called before the first frame update
    private void Start()
    {
        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / joystickSizeMovement;
    }

    public void PointerDown()
    {
        joystick.gameObject.SetActive(true);
        joystickBG.gameObject.SetActive(true);
        joystick.transform.position = Input.mousePosition;
        joystickBG.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = (PointerEventData)baseEventData;
        Vector2 dragPos = pointerEventData.position;
        joystickVec = (dragPos - joystickTouchPos).normalized;

        float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);

        if (joystickDist < joystickRadius)
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickDist;
        }
        else
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickRadius;
        }
    }

    public void PointerUp()
    {
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        joystickBG.transform.position = joystickOriginalPos;
        joystick.gameObject.SetActive(false);
        joystickBG.gameObject.SetActive(false);
    }
}