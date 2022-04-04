using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : MonoBehaviour
{
    [SerializeField] private GameObject unitSmall;
    private Vector3 spawnPosition;
    void Start()
    {
        
    }
    public void CreateUnitSmall()
    {
        spawnPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + Random.Range(-1,4), 0);
        GameObject instanti = Instantiate(unitSmall, spawnPosition, Quaternion.identity);
        UnitSkills.Enemy.Add(instanti);
    }

}
