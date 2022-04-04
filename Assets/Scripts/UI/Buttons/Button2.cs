using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject unitSmall;
    private Vector3 spawnPosition;
    void Start()
    {

    }
    public void CreateUnitSmall()
    {
        spawnPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + Random.Range(-1, 4), 0);
        
        GameObject instanti = Instantiate(unitSmall, spawnPosition, Quaternion.Euler(180, 0, 0));
        UnitSkills.Enemy.Add(instanti);
    }
}
