using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAminmations : MonoBehaviour
{
   // UnitEventManager unitEventManager;
    [SerializeField]public Animator animator;
    public void PlayAnimationAttack(bool distanceCheck, float Speed)
    {
        animator.SetBool("OrkWalk", distanceCheck);
    }
    public void PlayAnimationDeath(float health)
    {
        animator.SetFloat("Die", health);
    }
}
