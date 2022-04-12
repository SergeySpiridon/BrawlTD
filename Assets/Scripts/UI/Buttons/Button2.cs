using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject unitSmall;
    private Vector3 spawnPosition;
    Unit—haracteristic units;
    void Start()
    {

    }
    public void CreateUnitSmall()
    {
        spawnPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + Random.Range(-1, 4), 0);
        
        GameObject instanti = Instantiate(unitSmall, spawnPosition, Quaternion.Euler(0, 0, 0));
        Unit—haracteristic.Enemy.Add(instanti);
        //Debug.Log(instanti);
      //  Debug.Log(3);
    }
}
