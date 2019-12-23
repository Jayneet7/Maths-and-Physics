using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    [SerializeField] private string horiInname;
    [SerializeField] private string vertInname;
    [SerializeField] private float movementSpeed;

    private CharacterController characterController;

    [SerializeField] private AnimationCurve jumpFalloff;
    [SerializeField] private float jumpMulti;
    [SerializeField] private KeyCode jumpKey;

    private bool isJumping;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float horiIn = Input.GetAxis(horiInname) * movementSpeed;
        float vertIn = Input.GetAxis(vertInname) * movementSpeed;

        Vector3 forwardMove = transform.forward * vertIn;
        Vector3 rightMove = transform.right * horiIn;

        characterController.SimpleMove(forwardMove + rightMove);
        JumpIn();
    }

    private void JumpIn()
    {
        if(Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEnvet());
        }
    }

    private IEnumerator JumpEnvet()
    {
        characterController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;
        
        do
        {
            float jumpForce = jumpFalloff.Evaluate(timeInAir);
            characterController.Move(Vector3.up * jumpForce * jumpMulti * Time.deltaTime );
            timeInAir += Time.deltaTime;
            yield return null;
        }
        while (!characterController.isGrounded && characterController.collisionFlags != CollisionFlags.Above);
        characterController.slopeLimit = 45.0f;
        isJumping = false;
    }
}
