using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField]
    Animator playerAnimator;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerMovement(Vector3 move)
    {
        if (move.magnitude > 0)
        {
            PlayRunAnimation();
            playerAnimator.transform.forward = move.normalized;
        }
        else
            PlayIdleAnimation();
    }

    void PlayRunAnimation()
    {
        playerAnimator.Play("Run");

    }

    void PlayIdleAnimation()
    {
        playerAnimator.Play("Idle");
    }
}
