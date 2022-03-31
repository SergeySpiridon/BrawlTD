using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyChange : MonoBehaviour
{
  //  UnitSkills cost;
    private Text text;
    private float Money = 100;
    public void Start()
    {
        text = GetComponent<Text>();
        EventManager.KillEnemy += ChangeMoney;
        text.text = Money.ToString();
    }
    public void ChangeMoney()
    {
        Money += UnitSkills.costEnemy * 2;
        float MoneyRound = Mathf.Round(Money);
        Debug.Log(Money); 
        text.text = MoneyRound.ToString();
    }
}
