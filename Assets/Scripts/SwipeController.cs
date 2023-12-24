using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class SwipeController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public JumpBehavior jumpBehavior;
    public GroundCheck groundCheck = null;
    public Animator animator;

    private int desiredLane;
    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private bool isSwiping = false;
    private bool inRolling = false;
    public void Start()
    {

    }

    public void Update()
    {
        CheckForSwipe();
        playerMovement.moveOnLane(desiredLane);
    }

    private void CheckForSwipe()
    {
        if (Touchscreen.current.primaryTouch.isInProgress)
        {
            TouchPhaseControl touchPhaseControl = Touchscreen.current.primaryTouch.phase;
            TouchPhase touchPhase = touchPhaseControl.ReadValue();

            switch (touchPhase)
            {
                case UnityEngine.InputSystem.TouchPhase.Began:
                    touchStartPos = Touchscreen.current.primaryTouch.position.ReadValue();
                    isSwiping = true;
                    break;

                case UnityEngine.InputSystem.TouchPhase.Moved:
                    if (isSwiping)
                    {
                        touchEndPos = Touchscreen.current.primaryTouch.position.ReadValue();
                        Vector2 swipeDelta = touchEndPos - touchStartPos;

                        float swipeThreshold = 50f;

                        if (swipeDelta.magnitude > swipeThreshold)
                        {
                            if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                            {
                                if (swipeDelta.x > 0)
                                {
                                    // Swipe droite
                                    if (desiredLane == 1)
                                        desiredLane = 2;
                                    else
                                        desiredLane = 3;
                                }
                                else
                                {
                                    // Swipe gauche
                                    if (desiredLane == 3)
                                        desiredLane = 2;
                                    else
                                        desiredLane = 1;
                                }
                            }
                            else
                            {
                                if (swipeDelta.y > 0)
                                {
                                    // Swipe haut
                                    if (groundCheck.isGroundCheck)
                                    {
                                        animator.SetBool("isJumping", true);
                                        transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                                        StartCoroutine(jumpingEnding());
                                    }
                                }
                                else
                                {
                                    // Swipe bas
                                    if (groundCheck.isGroundCheck)
                                    {
                                        Debug.Log("roulade");
                                        animator.SetBool("isRolling", true);
                                        StartCoroutine(rollingEnding());
                                    }
                                }
                            }

                            isSwiping = false;
                        }
                    }
                    break;

                case UnityEngine.InputSystem.TouchPhase.Ended:
                    isSwiping = false;
                    break;
            }
        }
    }
    IEnumerator rollingEnding()
    {
        yield return new WaitForSeconds(1);
        animator.SetBool("isRolling", false);
    }
    IEnumerator jumpingEnding()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("jumpingEnding");
        animator.SetBool("isJumping", false);
    }

}