using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBuyZone : MonoBehaviour
{
    [SerializeField] private Animator animatorBuyZone;

    public void StartAniatorBuyZone(bool play)
    {
        animatorBuyZone.SetBool("BuyZoneOn", play);
    }
    public void PlayAnimatorZone(bool play)
    {
        animatorBuyZone.SetBool("BuyZoneOff", play);
    }
}
