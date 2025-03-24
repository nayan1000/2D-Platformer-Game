using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        Vector2 scale= transform.localScale;
        animator.SetFloat("Speed",Mathf.Abs( speed));
        
        if(speed < 0)
        {
            scale.x= -1f* Mathf.Abs( speed );
        }else if (speed > 0)
        {
            scale.x=Mathf.Abs(speed);
        }
        transform.localScale = scale;   
    }
}
