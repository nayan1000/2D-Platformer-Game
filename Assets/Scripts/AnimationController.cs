using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D boxCollider;
    private Vector2 boxcolSize;
    private Vector2 boxcolOffset;

    private void Start()
    {
        boxcolSize= boxCollider.size;
        boxcolOffset= boxCollider.offset;
    }

    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 scale= transform.localScale;
        animator.SetFloat("Speed",Mathf.Abs(speed));
        
        if(speed < 0)
        {
            scale.x= -1f* Mathf.Abs( speed );
        }else if (speed > 0)
        {
            scale.x=Mathf.Abs(speed);
        }
        transform.localScale = scale;

        PlayJumpAnimation(verticalInput);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            PlayCrouchAnimation(true);
        }
        else
        {
            PlayCrouchAnimation(false);
        }
            
    }


    private void PlayJumpAnimation(float verticalInput)
    {
        if (verticalInput > 0)
        {
            animator.SetTrigger("Jump");
        }
       
    }

    private void PlayCrouchAnimation(bool crouch)
    {
       if(crouch== true)
        {
            float sizeX = 0.483f;
            float sizeY = 1.173f;
            float OffX = -0.003f;
            float OffY = 0.553f;

            boxCollider.offset=new Vector2(OffX, OffY);
            boxCollider.size= new Vector2(sizeX, sizeY);

        }
        else
        {
            boxCollider.offset =boxcolOffset;
            boxCollider.size = boxcolSize;
        }
            animator.SetBool("Crouch", crouch);
    }
}
