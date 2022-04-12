using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventManager : MonoBehaviour
{
    public static event Action KillEnemy;
    public static event Action<float> BuyUnit;
    public static event Action StartNight;
    public static void EnemyDie()
    {
        KillEnemy?.Invoke();
    }
    public static void UnitCost(float cost)
    {
        BuyUnit?.Invoke(cost);
    }
    public static void KillOurUnits()
    {
        StartNight?.Invoke();
    }
}
