using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCas2 : MonoBehaviour
{
    private bool _trigger =false;
    [SerializeField] private Button button;
    public void EventClick()
    {
        if (!_trigger)
        {
            var getMoney = float.Parse(button.GetComponentInChildren<Text>().text.ToString());
            EventManager.BuyMoney(getMoney);
            _trigger = true;
        }
    }

}
