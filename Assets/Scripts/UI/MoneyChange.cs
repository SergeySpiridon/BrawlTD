using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyChange : MonoBehaviour
{
    //  UnitSkills cost;
    public Animator anim;
    private Text text;
    private float Money = 500;
    public static float moneyRound;
    public void Start()
    {
        moneyRound = Money;
        text = GetComponent<Text>();
        EventManager.KillEnemy += MoneyForKill;
        EventManager.BuyUnit += MoneyForBuyUnit;
        EventManager.ClickButtonCas1 += ChangeMoneyForButtonUp1;
        EventManager.ClickButtonCas2 += ChangeMoneyGetMoney;
        text.text = Money.ToString();
    }
    public void MoneyForKill()
    {
        anim.SetBool("Trigger", true);
        Money += Unit—haracteristic.costEnemy * 2;
        moneyRound = Mathf.Round(Money);
        ChangeMoney();
    }
    public void MoneyForBuyUnit(float costUnit)
    {
        Money -= costUnit;
        moneyRound = Mathf.Round(Money);
        ChangeMoney();

    }
    public void ChangeMoneyForButtonUp1(float costButton)
    {
        Money -= costButton;
        moneyRound = Mathf.Round(Money);
        ChangeMoney();
    }
    public void ChangeMoneyGetMoney(float getMoney)
    {
        Money += getMoney;
        moneyRound = Mathf.Round(Money);
        ChangeMoney();
    }
    public void ChangeMoney()
    {
        text.text = moneyRound.ToString();

    }

    public void SetFlagFalse()
    {
        anim.SetBool("Trigger", false);
    }
}
