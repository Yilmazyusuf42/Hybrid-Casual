using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Objects")]
        
    [SerializeField] JoystickController joystickController;
    [SerializeField] PlayerAnimatorController playerAC;
    CharacterController characterController;

    Vector3 moveVector;
    [Header("Settings")]
    [SerializeField] float speed;

    float gravity = -9.8f;
    float gravityMultiplier = 3f;
    float gravityVelocity;

    // Start is called before the first frame update

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Debug.Log(characterController.isGrounded);
    }

    void MovePlayer()
    {
        moveVector = joystickController.MoveDirection() * speed * Time.deltaTime / Screen.width;
        moveVector.z = moveVector.y;
        moveVector.y = 0;
        playerAC.PlayerMovement(moveVector);
        ApplyGravity();
        characterController.Move(moveVector);
    }

    void ApplyGravity()
    {
        if(characterController.isGrounded && gravityVelocity < 0.0f)
        {
            gravityVelocity = -1f;
        }
        else
        {
            gravityVelocity += gravity * gravityMultiplier * Time.deltaTime;
        }
        moveVector.y = gravityVelocity;
    }
}
