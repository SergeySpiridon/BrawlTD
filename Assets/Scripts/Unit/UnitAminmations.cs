using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAminmations : MonoBehaviour
{
   // UnitEventManager unitEventManager;
    [SerializeField]public Animator animator;
    public void PlayAnimationAttack(bool distanceCheck, float Speed)
    {
        if(distanceCheck)
        animator.speed = 1.4f * Speed;
        else
            animator.speed = 1.4f;
        animator.SetBool("OrkWalk", distanceCheck);
    }
    public void PlayAnimationDeath(float health)
    {
        animator.speed = 1.4f;
        animator.SetFloat("Die", health);
    }
}
