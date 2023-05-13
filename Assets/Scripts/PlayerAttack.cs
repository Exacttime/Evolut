using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator attackAnimation;
    private float animationTime = 0.10f;
    private float timer = 0f;
    [SerializeField] private bool attacking = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }
        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= animationTime)
            {
                attacking = false;
                attackAnimation.SetBool("Bool", attacking);
            }
        }

    }
    private void Attack()
    {
        attacking = true;
        attackAnimation.SetBool("Bool", attacking);
        
    }
}
