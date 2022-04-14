using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventManager : MonoBehaviour
{
    public static event Action KillEnemy;
    public static event Action<float> BuyUnit;
    public static event Action StartNight;
    public static event Action<float> ClickButtonCas1;
    public static event Action<float> ClickButtonCas2;
    public static event Action<float, GameObject> DealDmgForCrystall;
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
    public static void BuyPowerUp(float cost)
    {
        ClickButtonCas1?.Invoke(cost);
    }
    public static void BuyMoney(float cost)
    {
        ClickButtonCas2?.Invoke(cost);
    }
    public static void DealDmg(float dmg, GameObject crystall)
    {
        DealDmgForCrystall?.Invoke(dmg, crystall);
    }

}
