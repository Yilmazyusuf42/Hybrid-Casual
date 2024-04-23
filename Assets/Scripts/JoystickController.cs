using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    [SerializeField] RectTransform joystickOutline;
    [SerializeField] RectTransform joystickKnob;
    [SerializeField] float knobSpeed;
    Vector3 move;
    bool isJoystickRun;
    Vector3 tapPos;

    // Start is called before the first frame update
    void Start()
    {
        JoystickHide();
    }

    // Update is called once per frame
    void Update()
    {
        if(isJoystickRun)
            isJoystickRunning();

    }


    void isJoystickRunning()
    {

        Vector3 currentPos = Input.mousePosition;

        Vector3 direction = (currentPos - tapPos);
        float moveMagnitude = direction.magnitude * knobSpeed / Screen.width;

        moveMagnitude = Mathf.Min(moveMagnitude, joystickOutline.rect.width / 2);
        move = direction.normalized * moveMagnitude;

        Vector3 targetPos = move + tapPos;
        joystickKnob.position = targetPos;


        if (Input.GetMouseButtonUp(0))
            JoystickHide();
    }


    void JoystickShow()
    {
        joystickOutline.gameObject.SetActive(true);
        isJoystickRun = true;
        tapPos = Input.mousePosition;
        joystickOutline.position = tapPos;
    }

    void JoystickHide()
    {
        joystickOutline.gameObject.SetActive(false);
        isJoystickRun=false;
        move = Vector3.zero;
    }

    public Vector3 MoveDirection()
    {
        return move;
    }


    public void TapOnTheScreen()
    {
        JoystickShow();
    }
}
