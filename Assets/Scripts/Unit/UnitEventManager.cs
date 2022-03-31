using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class UnitEventManager : MonoBehaviour
{
    public static event Action Animations;
    
    public void AnimationAttack()
    {
        Animations?.Invoke();
    }
}
