using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RouladeBehavior : MonoBehaviour
{
    public InputActionReference jumpActionRef = null;
    public Animator animator = null;
    public Rigidbody rigidbody = null;
    public float jumpForce = 100.0f;
    public GroundCheck groundCheck = null;
    private bool isJumping = false;
    private BoxCollider boxCollider; // Référence au BoxCollider attaché au Rigidbody

    void Start()
    {
        // Récupérer le BoxCollider attaché au Rigidbody
        boxCollider = GetComponent<BoxCollider>();
    }

    void OnEnable()
    {
        jumpActionRef.action.performed += OnJumpInputPressed;
    }

    void OnDisable()
    {
        jumpActionRef.action.performed -= OnJumpInputPressed;
    }
    private void OnJumpInputPressed(InputAction.CallbackContext context)
    {
        Jump();
    }

    public void Jump()
    {
        if (groundCheck.isGroundCheck)
        {
            isJumping = true;
            animator.SetBool("isJumping", isJumping);
            rigidbody.AddForce(Vector3.up * jumpForce);

            boxCollider.size = new Vector3(0, 0, 0);

        }
        else
        {
            isJumping = false;
            animator.SetBool("isJumping", isJumping);
        }


    }

}

