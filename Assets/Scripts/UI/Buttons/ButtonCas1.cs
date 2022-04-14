using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ButtonCas1 : MonoBehaviour
{ 
    private List<Action> powerUp = new List<Action>();
    [SerializeField] private Button button;
    [SerializeField] private UnitÑharacteristic skills;
    [Header("Sprites")]
    public Sprite spriteUpDmg;
    public Sprite spriteUpHelath;
    public Sprite spriteUpSpeedAtack;
    private bool trigger;
    private Action methodRND;

    private void Start()
    {

    }

    public void RandomBoost()
    {
        //Äîëæíà êíîïî÷êà ïğèíèìàòü ñïğàéò âûïàâøåãî óñèëåíèÿ.
        AddList();
        methodRND = powerUp[Random.Range(0, powerUp.Count)];
        methodRND.Invoke();
        powerUp.Clear();

    }

    private void UpDmg()
    {
        button.GetComponent<Image>().overrideSprite = spriteUpDmg;
        if (trigger)
        {
            skills.GetComponent<UnitÑharacteristic>().Damage += 5;
        }
        
    }
    private void UpHealth()
    {
        button.GetComponent<Image>().overrideSprite = spriteUpHelath;
        if (trigger)
        {
            skills.GetComponent<UnitÑharacteristic>().Health += 25;
        }
    }
    private void UpSpeedAtack()
    {
        button.GetComponent<Image>().overrideSprite = spriteUpSpeedAtack;
        if (trigger)
        {
            skills.GetComponent<UnitÑharacteristic>().SpeedAttack += 0.2f;
        }
    }
    private void AddList()
    {
        powerUp.Add(UpDmg);
        powerUp.Add(UpHealth);
        powerUp.Add(UpSpeedAtack);
    }
    public void EventClick()
    {

        var costPowerUp = float.Parse(button.GetComponentInChildren<Text>().text.ToString()) * -1;
          Debug.Log(costPowerUp);
        if (MoneyChange.moneyRound > costPowerUp)
        {

            EventManager.BuyPowerUp(costPowerUp);
            //  Debug.Log(MoneyChange.moneyRound);
            trigger = true;
            methodRND.Invoke();
            trigger = false;
        }
        else Debug.Log(costPowerUp);
    }

}
