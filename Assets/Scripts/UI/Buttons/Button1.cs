using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : MonoBehaviour
{
    [SerializeField] private GameObject unitSmall;
    Unit—haracteristic units;
    //[SerializeField] private MoneyChange moneyCost;
    [SerializeField] private float costUnit;

    private Vector3 spawnPosition;
    void Start()
    {
        costUnit = unitSmall.GetComponent<Unit—haracteristic>().Cost;
    }
    public void CreateUnitSmall()
    {
        Debug.Log(costUnit + " " + MoneyChange.moneyRound);

            if (MoneyChange.moneyRound >= costUnit)
            {
                EventManager.UnitCost(costUnit);
                spawnPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + Random.Range(-1, 4), 0);
                GameObject instanti = Instantiate(unitSmall, spawnPosition, Quaternion.identity);
            }
       
    }

}
