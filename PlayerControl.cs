using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour
{

    private CharacterController characterController;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

	if (characterController.isGrounded) {
            //　左右前方の入力値をアニメーションパラメータ―に渡す
            animator.SetFloat("ForwardSpeed", Input.GetAxis("Vertical"));
            animator.SetFloat("LateralSpeed", Input.GetAxis("Horizontal"));
	    animator.SetFloat("ForwardSpeed", CrossPlatformInputManager.GetAxis ("Vertical"));
            animator.SetFloat("LateralSpeed", CrossPlatformInputManager.GetAxis ("Horizontal"));
	    //Debug.Log(CrossPlatformInputManager.GetAxis ("Vertical"));
	    //Debug.Log(CrossPlatformInputManager.GetAxis ("Horizontal"));
 
        }
    }

    
}
