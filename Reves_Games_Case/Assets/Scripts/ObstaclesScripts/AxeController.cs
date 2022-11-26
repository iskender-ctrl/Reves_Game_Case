using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{
    Animator animator;
    public float upSpeed = 0.3f;
    public float downSpeed = 2f;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AxeUpAnimationSpeed()
    {
        animator.speed = upSpeed;
    }
    public void AxeDownAnimationSpeed()
    {
        animator.speed = downSpeed;
    }
}
