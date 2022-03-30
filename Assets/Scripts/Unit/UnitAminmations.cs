using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAminmations : MonoBehaviour
{
    UnitEventManager unitEventManager;
    [SerializeField]public Animator animator;
    public void PlayAnimationAttack(bool distanceCheck)
    {
        if(distanceCheck)
        Debug.Log(distanceCheck);
        animator.SetBool("OrkWalk", distanceCheck);
   //     unitEventManager.AnimationAttack();
    }
}
