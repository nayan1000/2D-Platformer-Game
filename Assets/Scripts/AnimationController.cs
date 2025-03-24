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
        
    }
}
